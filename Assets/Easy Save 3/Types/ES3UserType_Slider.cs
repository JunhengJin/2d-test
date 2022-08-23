using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_Value")]
	public class ES3UserType_Slider : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_Slider() : base(typeof(UnityEngine.UI.Slider)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (UnityEngine.UI.Slider)obj;
			
			writer.WritePrivateField("m_Value", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (UnityEngine.UI.Slider)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_Value":
					instance = (UnityEngine.UI.Slider)reader.SetPrivateField("m_Value", reader.Read<System.Single>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_SliderArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_SliderArray() : base(typeof(UnityEngine.UI.Slider[]), ES3UserType_Slider.Instance)
		{
			Instance = this;
		}
	}
}