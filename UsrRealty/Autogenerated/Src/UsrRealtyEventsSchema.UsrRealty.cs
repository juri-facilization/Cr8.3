namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: UsrRealtyEventsSchema

	/// <exclude/>
	public class UsrRealtyEventsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public UsrRealtyEventsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public UsrRealtyEventsSchema(UsrRealtyEventsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("ad22320c-dd18-4a18-ba85-1d4b58b05b65");
			Name = "UsrRealtyEvents";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("d6465f5e-0a68-4715-a5ac-c9044f40c5f9");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,141,82,77,107,219,64,16,189,7,242,31,6,209,131,4,102,73,174,77,27,168,141,91,2,161,45,177,146,75,233,97,189,26,43,91,246,67,236,172,156,186,165,255,189,179,90,185,118,228,20,50,8,180,59,251,230,205,123,195,56,105,145,58,169,16,106,12,65,146,223,68,177,240,110,163,219,62,200,168,189,59,63,251,125,126,6,28,61,105,215,194,106,71,17,237,213,113,234,184,208,90,239,254,251,24,80,44,93,212,81,35,189,6,35,150,91,116,113,15,253,54,164,119,67,238,86,179,8,135,161,92,169,71,180,242,51,123,128,247,80,220,83,184,67,105,226,174,168,190,231,162,174,95,27,173,64,25,73,4,249,237,5,26,120,11,115,73,248,194,75,102,25,7,112,68,232,183,44,89,55,8,91,175,27,248,226,86,114,203,70,74,191,254,129,42,2,161,107,48,204,32,19,206,113,195,174,6,218,15,161,37,192,234,64,119,196,156,98,205,42,196,63,182,61,13,86,87,207,97,153,23,194,224,135,141,151,57,81,229,130,9,184,65,165,173,52,208,5,173,210,148,114,149,248,132,177,222,117,216,44,188,233,173,123,144,166,199,119,35,244,186,76,147,252,154,240,197,180,181,222,64,153,153,174,225,242,98,31,213,115,208,196,85,10,20,55,180,144,78,161,193,134,69,196,208,35,51,159,226,40,134,180,17,188,147,36,91,172,209,118,70,198,36,219,225,19,220,122,37,141,254,37,215,6,87,3,174,28,205,220,19,6,94,90,199,195,231,141,21,119,72,190,15,138,65,62,48,203,236,180,77,138,195,186,228,61,43,102,80,156,116,32,49,140,230,134,106,239,231,186,205,183,162,18,181,31,21,84,175,176,193,242,115,66,124,244,193,202,88,78,236,113,227,75,113,49,127,115,50,237,20,241,49,248,167,193,254,242,167,194,46,25,220,215,79,225,127,14,215,241,200,63,254,254,2,62,200,48,11,228,3,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateValueIsTooBigLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateValueIsTooBigLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5dbd2847-4ab1-194a-ff53-5e3cfe36d50f"),
				Name = "ValueIsTooBig",
				CreatedInPackageId = new Guid("d6465f5e-0a68-4715-a5ac-c9044f40c5f9"),
				CreatedInSchemaUId = new Guid("ad22320c-dd18-4a18-ba85-1d4b58b05b65"),
				ModifiedInSchemaUId = new Guid("ad22320c-dd18-4a18-ba85-1d4b58b05b65")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("ad22320c-dd18-4a18-ba85-1d4b58b05b65"));
		}

		#endregion

	}

	#endregion

}

