using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace WowGames.Models.EPay
{
    [XmlRoot(ElementName = "PROVIDER")]
    public class PROVIDER
    {
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlText]
        public string Text { get; set; }
        public override string ToString()
        {
            return $"{Text}";
        }
    }

    [XmlRoot(ElementName = "AMOUNT")]
    public class AMOUNT
    {
        [XmlAttribute(AttributeName = "CURRENCY")]
        public string CURRENCY { get; set; }
        [XmlAttribute(AttributeName = "MINAMOUNT")]
        public string MINAMOUNT { get; set; }
        [XmlAttribute(AttributeName = "MAXAMOUNT")]
        public string MAXAMOUNT { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "INFO")]
    public class INFO
    {
        [XmlElement(ElementName = "DISPLAY_NAME")]
        public string DISPLAY_NAME { get; set; }
        [XmlElement(ElementName = "SKU")]
        public string SKU { get; set; }
        [XmlElement(ElementName = "COUNTRY")]
        public string COUNTRY { get; set; }
        [XmlElement(ElementName = "LANGUAGE")]
        public string LANGUAGE { get; set; }
        [XmlElement(ElementName = "CATEGORY")]
        public string CATEGORY { get; set; }
        [XmlElement(ElementName = "DEVELOPER")]
        public string DEVELOPER { get; set; }
        [XmlElement(ElementName = "TERMS_AND_CONDITIONS_HTML")]
        public string TERMS_AND_CONDITIONS_HTML { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "BRAND")]
        public string BRAND { get; set; }
        [XmlElement(ElementName = "COMPANY")]
        public string COMPANY { get; set; }
        [XmlElement(ElementName = "CARD_WIDTH")]
        public string CARD_WIDTH { get; set; }
        [XmlElement(ElementName = "CARD_HEIGHT")]
        public string CARD_HEIGHT { get; set; }
        [XmlElement(ElementName = "PRODUCT_CLASSIFICATION")]
        public string PRODUCT_CLASSIFICATION { get; set; }
        [XmlElement(ElementName = "PUBLISHER")]
        public string PUBLISHER { get; set; }
        [XmlElement(ElementName = "PLATFORM")]
        public string PLATFORM { get; set; }
        [XmlElement(ElementName = "GENRE")]
        public string GENRE { get; set; }
        [XmlElement(ElementName = "PRODUCT_SUBCLASSIFICATION")]
        public string PRODUCT_SUBCLASSIFICATION { get; set; }
        [XmlElement(ElementName = "RELEASE_DATE")]
        public string RELEASE_DATE { get; set; }
        [XmlElement(ElementName = "PREORDER_DATE")]
        public string PREORDER_DATE { get; set; }
        [XmlElement(ElementName = "AGE_RATING")]
        public string AGE_RATING { get; set; }
        [XmlElement(ElementName = "AGE_CLASSIFICATION")]
        public string AGE_CLASSIFICATION { get; set; }
        [XmlElement(ElementName = "REDEMPTION_LINK")]
        public string REDEMPTION_LINK { get; set; }
        [XmlElement(ElementName = "CUSTOMER_SUPPORT_INFORMATION")]
        public string CUSTOMER_SUPPORT_INFORMATION { get; set; }
        [XmlElement(ElementName = "SPOKEN_LANGUAGES")]
        public string SPOKEN_LANGUAGES { get; set; }
        [XmlElement(ElementName = "SUBTITLE_LANGUAGES")]
        public string SUBTITLE_LANGUAGES { get; set; }
        [XmlElement(ElementName = "DESCRIPTION_LONG")]
        public string DESCRIPTION_LONG { get; set; }
        [XmlElement(ElementName = "DESCRIPTION_SHORT")]
        public string DESCRIPTION_SHORT { get; set; }
        [XmlElement(ElementName = "DESCRIPTION_REDEMPTION")]
        public string DESCRIPTION_REDEMPTION { get; set; }
        [XmlElement(ElementName = "TERMS_AND_CONDITIONS")]
        public string TERMS_AND_CONDITIONS { get; set; }
        [XmlElement(ElementName = "TECHNICAL_INFORMATION")]
        public string TECHNICAL_INFORMATION { get; set; }
        [XmlElement(ElementName = "SUGESTED_AMOUNT")]
        public string SUGESTED_AMOUNT { get; set; }
    }

    [XmlRoot(ElementName = "INFOS")]
    public class INFOS
    {
        [XmlElement(ElementName = "INFO")]
        public List<INFO> INFO { get; set; }
    }

    [XmlRoot(ElementName = "MEDIA")]
    public class MEDIA
    {
        [XmlElement(ElementName = "PROVIDER")]
        public string PROVIDER { get; set; }
        [XmlElement(ElementName = "LINE_OF_BUSINESS")]
        public string LINE_OF_BUSINESS { get; set; }
        [XmlElement(ElementName = "THUMBNAIL")]
        public string THUMBNAIL { get; set; }
        [XmlElement(ElementName = "LOGO")]
        public string LOGO { get; set; }
        [XmlElement(ElementName = "RECEIPT")]
        public string RECEIPT { get; set; }
        [XmlElement(ElementName = "PROVIDER_LOGO")]
        public string PROVIDER_LOGO { get; set; }
        [XmlElement(ElementName = "ARTICLE_IMAGE")]
        public string ARTICLE_IMAGE { get; set; }
    }

    [XmlRoot(ElementName = "ARTICLE")]
    public class ARTICLE
    {
        [XmlElement(ElementName = "ENABLED")]
        public string ENABLED { get; set; }
        [XmlElement(ElementName = "TYPE")]
        public string TYPE { get; set; }
        [XmlElement(ElementName = "EAN")]
        public string EAN { get; set; }
        [XmlElement(ElementName = "NAME")]
        public string NAME { get; set; }
        [XmlElement(ElementName = "DISPLAY_NAME")]
        public string DISPLAY_NAME { get; set; }
        [XmlElement(ElementName = "USAGE")]
        public string USAGE { get; set; }
        [XmlElement(ElementName = "PROVIDER")]
        public PROVIDER PROVIDER { get; set; }
        [XmlElement(ElementName = "AMOUNT")]
        public AMOUNT AMOUNT { get; set; }
        [XmlElement(ElementName = "INFOS")]
        public INFOS INFOS { get; set; }
        [XmlElement(ElementName = "MEDIA")]
        public MEDIA MEDIA { get; set; }
        [XmlAttribute(AttributeName = "ID")]
        public string ID { get; set; }
        [XmlIgnore]
        public string Description
        {
            get
            {
                return string.IsNullOrWhiteSpace(NAME) ? DISPLAY_NAME : NAME;
            }
        }
    }

    [XmlRoot(ElementName = "CATALOG")]
    public class CATALOG
    {
        [XmlElement(ElementName = "ARTICLE")]
        public List<ARTICLE> ARTICLE { get; set; }
    }

    [XmlRoot(ElementName = "RESPONSE")]
    public class CatalogResponse
    {
        [XmlElement(ElementName = "TERMINALID")]
        public string TERMINALID { get; set; }
        [XmlElement(ElementName = "LOCALDATETIME")]
        public string LOCALDATETIME { get; set; }
        [XmlElement(ElementName = "SERVERDATETIME")]
        public string SERVERDATETIME { get; set; }
        [XmlElement(ElementName = "CATALOGLASTUPDATE")]
        public string CATALOGLASTUPDATE { get; set; }
        [XmlElement(ElementName = "CATALOGTOTALPAGES")]
        public string CATALOGTOTALPAGES { get; set; }
        [XmlElement(ElementName = "CATALOGPAGE")]
        public string CATALOGPAGE { get; set; }
        [XmlElement(ElementName = "TXID")]
        public string TXID { get; set; }
        [XmlElement(ElementName = "HOSTTXID")]
        public string HOSTTXID { get; set; }
        [XmlElement(ElementName = "LIMIT")]
        public string LIMIT { get; set; }
        [XmlElement(ElementName = "RESULT")]
        public string Result { get; set; }
        [XmlElement(ElementName = "RESULTTEXT")]
        public string ResultText { get; set; }
        [XmlElement(ElementName = "CATALOG")]
        public CATALOG CATALOG { get; set; }
        [XmlAttribute(AttributeName = "TYPE")]
        public string TYPE { get; set; }

        public static CatalogResponse LoadFromXML(string xml)
        {
            var xmlSerializer = new XmlSerializer(typeof(CatalogResponse));
            using (TextReader reader = new StringReader(xml))
            {
                return xmlSerializer.Deserialize(reader) as CatalogResponse;
            }
        }
    }

}
