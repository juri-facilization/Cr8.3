 namespace Terrasoft.Configuration
{
	using System.Collections.Generic;
    using System.Net;
	using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.ServiceModel.Activation;
    using Terrasoft.Core.DB;
    using Terrasoft.Web.Common;
    using System;
    using System.Web.SessionState;
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class CreatioWebService : BaseService, IReadOnlySessionState
    {
		//metodat
		//shto me ESQ
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "InsertAdvertisement", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public InsertResult InsertAdvertisement(AdvertisementBlock advertisementBlock)
		{
			try
			{
				var advertisementSchema = UserConnection.EntitySchemaManager.GetInstanceByName("UsrRealtyAdvertisement");
			    var advertisement = advertisementSchema.CreateEntity(UserConnection);

			    advertisement.SetDefColumnValues();
				
				var newId = Guid.NewGuid();
			    advertisement.SetColumnValue("Id", newId);

				advertisement.SetColumnValue("UsrTitle", advertisementBlock.Title);
			    advertisement.SetColumnValue("UsrDescription", advertisementBlock.Description);
			    if (advertisementBlock.StartDate.HasValue)
					advertisement.SetColumnValue("UrStartDate", advertisementBlock.StartDate.Value);
			    if (advertisementBlock.EndDate.HasValue)
					advertisement.SetColumnValue("UsrEndDate", advertisementBlock.EndDate.Value);

			    var saved = advertisement.Save();

				return new InsertResult {
			        Success = saved,
					RecordId = saved ? (Guid?)newId : null,
			        Message = saved ? "Created successfully." : "Save failed."
			    };
			}
			catch (Exception ex)
		    {
	        // Log this or return false for now
	        throw new WebFaultException<string>("Error: " + ex.Message, HttpStatusCode.BadRequest);
		    }
		}

		//shto non ESQ
		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "InsertAdvertisementNonESQ", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public InsertResult InsertAdvertisementNonESQ(AdvertisementBlock advertisementBlock)
		{
			string insertSql = @"
					    INSERT INTO UsrRealtyAdvertisement (Id, UsrTitle, UsrDescription, UrStartDate, UsrEndDate, CreatedOn)
					    VALUES (@Id, @Title, @Description, @StartDate, @EndDate, CURRENT_TIMESTAMP)";
			
			try
			{
				var newId = Guid.NewGuid();

				//var dbExecutor = UserConnection.EnsureDBConnection();
				var parameters = new QueryParameterCollection {
				    new QueryParameter("Id", newId),
				    new QueryParameter("Title", advertisementBlock.Title),
				    new QueryParameter("Description", advertisementBlock.Description),
				    new QueryParameter("StartDate", advertisementBlock.StartDate ?? (object)DBNull.Value),
				    new QueryParameter("EndDate", advertisementBlock.EndDate ?? (object)DBNull.Value)
				};

				UserConnection.EnsureDBConnection().Execute(insertSql, parameters);

				return new InsertResult {
			    Success = true,
			    RecordId = newId,
			    Message = "Inserted using raw SQL."
				};
			}
			catch (Exception ex)
		    {
	        // Log this or return false for now
	        throw new WebFaultException<string>("Error: " + ex.Message, HttpStatusCode.BadRequest);
		    }
		}
		
		//perditeso emrin me ESQ
		[OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateNameById", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool UpdateNameById(Guid id, string newName)
        {
            try
			{
		        var advertisementSchema = UserConnection.EntitySchemaManager.GetInstanceByName("UsrRealtyAdvertisement");
		        var advertisement = advertisementSchema.CreateEntity(UserConnection);

		        if (!advertisement.FetchFromDB(id))
		        {
		            throw new WebFaultException<string>($"Advertisement with Id {id} not found", HttpStatusCode.NotFound);
		        }

		        advertisement.SetColumnValue("UsrTitle", newName);
		        return advertisement.Save();
		    }
		    catch (Exception ex)
		    {
		        throw new WebFaultException<string>($"Error: {ex.Message}", HttpStatusCode.BadRequest);
		    }
        }

		//perditeso emrin non ESQ
		[OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "UpdateNameByIdNonESQ", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool UpdateNameByIdNonESQ(Guid id, string newName)
        {
            try
			{
		        Update update = new Update(UserConnection, "UsrRealtyAdvertisement")
							        .Set("UsrTitle", Column.Parameter(newName))
							        .Where("Id").IsEqual(Column.Parameter(id))
				                as Update;
            bool result = update.Execute() > 0;
            return result;
		    }
		    catch (Exception ex)
		    {
		        throw new WebFaultException<string>($"Error: {ex.Message}", HttpStatusCode.BadRequest);
		    }
        }

		//fshi me ESQ
		[OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteAdvertisementById", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool DeleteAdvertisementById(Guid id)
        {
            try
			{
		        var advertisementSchema = UserConnection.EntitySchemaManager.GetInstanceByName("UsrRealtyAdvertisement");
		        var advertisement = advertisementSchema.CreateEntity(UserConnection);

		        if (!advertisement.FetchFromDB(id))
		        {
		            throw new WebFaultException<string>($"Advertisement with Id {id} not found", HttpStatusCode.NotFound);
		        }

		        return advertisement.Delete();
		    }
		    catch (Exception ex)
		    {
		        throw new WebFaultException<string>($"Error: {ex.Message}", HttpStatusCode.BadRequest);
		    }
        }

		//fshi non ESQ
		[OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "DeleteAdvertisementByIdNonESQ", BodyStyle = WebMessageBodyStyle.Wrapped,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        public bool DeleteAdvertisementByIdNonESQ(Guid id)
        {
            try
			{
		        Delete delete = new Delete(UserConnection)
								    .From("UsrRealtyAdvertisement")
								    .Where("Id").IsEqual(Column.Parameter(id)) 
								as Delete;
            bool result = delete.Execute() > 0;
            return result;
		    }
		    catch (Exception ex)
		    {
		        throw new WebFaultException<string>($"Error: {ex.Message}", HttpStatusCode.BadRequest);
		    }
        }

    }
	//DTO class for Advertisemnt
	public class AdvertisementBlock
	{
	    public string Title { get; set; }
	    public string Description { get; set; }
	    public DateTime? StartDate { get; set; }
	    public DateTime? EndDate { get; set; }
	}
	
	public class InsertResult 
	{
	    public bool Success { get; set; }
	    public Guid? RecordId { get; set; }
	    public string Message { get; set; }
	}

}
