using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("TargetSlider", "TargetValue", "Target_sprite", "Target", "Dishe", "DisheDirty", "delaytime", "count", "valueControl")]
	public class ES3UserType_ValueControlor : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ValueControlor() : base(typeof(ValueControlor)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ValueControlor)obj;
			
			writer.WriteProperty("TargetSlider", instance.TargetSlider, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<UnityEngine.UI.Slider>)));
			writer.WriteProperty("TargetValue", instance.TargetValue, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<System.Single>)));
			writer.WriteProperty("Target_sprite", instance.Target_sprite, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(System.Collections.Generic.List<UnityEngine.Sprite>)));
			writer.WritePropertyByRef("Target", instance.Target);
			writer.WritePropertyByRef("Dishe", instance.Dishe);
			writer.WritePropertyByRef("DisheDirty", instance.DisheDirty);
			writer.WriteProperty("delaytime", instance.delaytime, ES3Type_float.Instance);
			writer.WritePrivateField("count", instance);
			writer.WriteProperty("valueControl", instance.valueControl, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(ValueControlor.ValueControl)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ValueControlor)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "TargetSlider":
						instance.TargetSlider = reader.Read<System.Collections.Generic.List<UnityEngine.UI.Slider>>();
						break;
					case "TargetValue":
						instance.TargetValue = reader.Read<System.Collections.Generic.List<System.Single>>();
						break;
					case "Target_sprite":
						instance.Target_sprite = reader.Read<System.Collections.Generic.List<UnityEngine.Sprite>>();
						break;
					case "Target":
						instance.Target = reader.Read<UnityEngine.GameObject>(ES3Type_GameObject.Instance);
						break;
					case "Dishe":
						instance.Dishe = reader.Read<Item>();
						break;
					case "DisheDirty":
						instance.DisheDirty = reader.Read<Item>();
						break;
					case "delaytime":
						instance.delaytime = reader.Read<System.Single>(ES3Type_float.Instance);
						break;
					case "count":
					instance = (ValueControlor)reader.SetPrivateField("count", reader.Read<System.Int32>(), instance);
					break;
					case "valueControl":
						instance.valueControl = reader.Read<ValueControlor.ValueControl>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ValueControlorArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ValueControlorArray() : base(typeof(ValueControlor[]), ES3UserType_ValueControlor.Instance)
		{
			Instance = this;
		}
	}
}