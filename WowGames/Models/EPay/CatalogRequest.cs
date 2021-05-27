using System;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace WowGames.Models.EPay
{
	[XmlRoot(ElementName = "TERMINALID")]
	public class TERMINALID
	{
		public TERMINALID()
		{
			RetailerAccount = ConfigurationManager.AppSettings["EPayRetailerAcc"];
			StoreId = ConfigurationManager.AppSettings["EPayStore"];
			Country = "BR";
			Text = ConfigurationManager.AppSettings["EPayTerminal"];
		}
		[XmlAttribute(AttributeName = "RETAILERACC")]
		public string RetailerAccount { get; set; }
		[XmlAttribute(AttributeName = "STOREID")]
		public string StoreId { get; set; }
		[XmlAttribute(AttributeName = "COUNTRY")]
		public string Country { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "REQUEST")]
	public class CatalogRequest
	{
        public CatalogRequest()
        {
			Username = ConfigurationManager.AppSettings["EPayUser"];
			Password = ConfigurationManager.AppSettings["EPayPassword"];
			LocalDateTime = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
			TXID = Guid.NewGuid().ToString();
            TERMINALID = new TERMINALID();
			TYPE = "CATALOG";
		}
		[XmlElement(ElementName = "USERNAME")]
		public string Username { get; set; }
		[XmlElement(ElementName = "PASSWORD")]
		public string Password { get; set; }
		[XmlElement(ElementName = "TERMINALID")]
		public TERMINALID TERMINALID { get; set; }
		[XmlElement(ElementName = "LOCALDATETIME")]
		public string LocalDateTime { get; set; }
		[XmlElement(ElementName = "TXID")]
		public string TXID { get; set; }
		[XmlAttribute(AttributeName = "TYPE")]
		public string TYPE { get; set; }

		public override string ToString()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(GetType());

			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, this);
				return textWriter.ToString();
			}
		}
	}

}
