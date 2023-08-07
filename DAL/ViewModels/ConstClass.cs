using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ConstClass
    {
        public class TARegions {
            public const string TAUS = "TAUS";
            public const string INTL = "INTERNATIONAL";
        }
        public class ConstBrandID
        {
            public const string TheodoreAlexander = "D1483451-48E9-4FB4-BA11-FA8552084DFF";
            public const string TAStudio = "87614FBC-9801-4312-A2D4-BC2F67C345AA";
        }
        public class ConstOtionGroupID
        {
            public const string BedGroupId = "663A4762-F2F5-4355-B1EE-D2147E2C31B5";
            public const string FinishGroupId = "64E527D1-AB63-4E11-AAF0-029E10B1AD8D";
            public const string SpecialGroupId = "CAD5A991-9B01-47D3-8A43-F6186A4601E0";
            public const string GroupUPD = "4223A7BB-EB4B-4AD2-9271-D5BBFDE284E2";
            public const string USUPDGroup = "29CB4321-A304-45C6-9D48-BB649CF3CBB0";
            public const string GroupLeatherInlay = "25ABC189-D2C8-4632-8A8A-6397BB468842";
            public const string GroupAXHFinish = "6D3916AD-04F4-4D9B-97E9-5A1FCDE2DCA2";
            public const string USFinishGroup = "111295C4-B75A-4435-B789-3CA594436937";
            public const string NailGroup = "A366F3B8-C4CA-499B-B7F9-341562186F05";
            public const string M2MUPDGroup = "A783B2ED-56EB-4FC1-B4BF-B92A76C1636B";
        }
        public class ConstType
        {
            public const string TABLETYPE = "8CD171BF-DF40-4216-A54E-8E99EF988847";
            public const string CHAIRTYPE = "1B7EF1A1-A9A9-40DE-8CC1-AC2120C0F293";
            public const string BEDTYPE = "18D34A6F-DB70-4E53-95A0-8C3CAF93E2E7";
            public const string DESKTYPE = "F8633391-1C3B-49AC-ACC9-A447489CCF12";
        }
        public class ConstTypeItemOption
        {
            public const string Origin = "Origin";
            public const string BedSize = "BedSize";
            public const string AvailableSizes = "AvailableSizes";
            public const string SpecialOption = "SpecialOption";
        }
        public class ConstCollection
        {
            public const string SteveLeungCollection = "E5CC4494-FCF1-42E5-B524-3901B1C1483C";
            public const string AlexaHamptonCollection = "9E007F80-83DD-467A-92ED-21AF909E9F76";
            public const string CabinetmakerCollection = "2C8C58DF-959C-4F0B-97D1-739127CBA2C3";
            public const string EchoesCollection = "B841A579-E547-47C2-B1EB-DF77057477B9";
            public const string JamieDrakeCollection = "F10FC0A9-D24F-4A9A-9587-622358B85320";
            public const string KenoBrosCollection = "D079DE8C-4F72-4ED6-8575-0376325F303C";
            public const string MichaelBermanCollection = "FE7AB707-597F-4C25-B30B-DB958321AABB";
            public const string RichardMishaanCollection = "3787F15E-EF6D-4AA8-BC49-FE61E0F523D7";
            public const string StephenChurchCollection = "3A7CD51D-1269-4C47-A91E-8041C5C18E21";
            public const string TAStudioNo1 = "AD742A70-2410-49C5-B2E8-ACD8EAA7411E";
            public const string TAStudioNo2 = "3B957809-BBD7-4D32-A6C5-F337527A039C";
            public const string TAStudioNo3 = "CB13AFBB-2261-413F-83EF-32218E000297";
            public const string TAStudioNo4 = "91EB6FA3-A4EE-4E38-B035-488B16D38006";
            public const string TAStudioRaia = "4973B119-2E24-4DA5-A585-F36C31E23F28";
            public const string TavelCollection = "D7F4067A-653E-45A0-BE78-5294CC16F456";

            public const string HolliCollection = "85CFC3ED-8876-436E-8159-B1E1025644C8";
            public const string FrenzyCollection = "461DA43B-0409-4EBD-8EF2-0FB911718678";
            public const string OasisCollection = "EAE0B15C-D6DE-4647-800B-94EFF1E79CAB";
            public const string IconicCollection = "C71176E5-F7C3-4FFF-BD82-012C0517595E";
            public const string GraceCollection = "6DF04F1B-3D4D-4F14-AB0A-A8661752711E";
        }
        public class ConstException
        {
            public const string BadRequestMess = "Please check the sent objects on the server";
            public const string NotFoundMess = "Your request is not found";
            public const string ServerErroMess = "Oop! Some thing went wrong";
        }
        public class ConstSidebarCountBy
        {
            public const string Brand = "BrandIds";
            public const string Collection = "CollectionIds";
            public const string Room = "RoomIds";
            public const string Type = "TypeIds";
            public const string LifeStyle = "LifeStyleIds";
            public const string Style = "StyleIds";
            public const string Shape = "ShapeIds";
            public const string Extending = "Extending";
            public const string ColourAndFinish = "ColourAndFinishIds";
        }
        public class ConstItemDownloads
        {
            public const string ChooseYourFabric = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Choose-Your-Fabric.pdf";
            public const string ChooseYourLeather = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Choose-Your-Leather.pdf";
            public const string ChooseYourLeatherInLay = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Choose-Your-Leather-In-Lay.pdf";
            public const string StudioFabric = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-Fabric-Availability.pdf";
            public const string TheAlexaHamptonCustomFinishBrochureUS = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/US/The_Alexa_Hampton_Custom_Finish_Brochure.pdf";
            public const string TheAlexaHamptonCustomFinishBrochureInternational = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/INT/The_Alexa_Hampton_Custom_Finish_Brochure.pdf";
            public const string ChooseYourFabricAndLeather = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Choose-Your-Fabric-And-Leather.pdf";
            public const string CustomPalette = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Custom-Palette.pdf";
            public const string CustomPaletteFinishOrderForm = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Custom-Palette-Finish-Order-Form.pdf";
            public const string COMForm = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/COM-form.pdf";
            public const string FinishOptions = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Finish-Options.pdf";
            public const string FrameAvailability = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Frame-Availability.pdf";
            public const string MadeToMeasureUpholsteryBrochure = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Made-to-Measure-Upholstery-Brochure.pdf";
            public const string MadeToMeasureUpholsteryTearsheet = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Made-to-Measure-Upholstery-Tearsheet.pdf";
            public const string NailOptions = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Nail-Options.pdf";
            public const string SleeperProgramCustomOptions = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Sleeper-Program-Custom-Options.pdf";
            
            public const string TAFabric = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TAU-Fabric-and-Trim-Availability.pdf";
            public const string TAStudioComForm = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-COM-form.pdf";
            public const string TAStudioNo1 = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-No1-Catalog.pdf";
            public const string TAStudioNo2 = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-No2-Catalog.pdf";
            public const string TAStudioNo3 = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-No3-Catalog.pdf";
            public const string TAStudioNo4 = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-No4-Catalog.pdf";
            public const string TAStudioRaia = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-Raia-Catalog.pdf";
            public const string TAStudioUpholsteryCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-Upholstery-Catalog.pdf";
            public const string TAUOrderForm = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TAU-order-form.pdf";
            public const string UpholsteryCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Upholstery-Catalog.pdf";
            public const string TavelFinishOption = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/Tavel-Finish-Options.pdf";
            public const string TavelCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Tavel-Catalog.pdf";

            public const string AlexaHamptonCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Alexa-Hampton-Catalog.pdf";
            public const string CabinetmakerCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Cabinetmaker-Catalog.pdf";
            public const string EchoesCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Echoes-Catalog.pdf";
            public const string JamieDrakeCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Jamie-Drake-Catalog.pdf";
            public const string KenoBrosCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Keno-Bros-Catalog.pdf";
            public const string MichaelBermanCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Michael-Berman-Catalog.pdf";
            public const string RichardMishaanCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Richard-Mishaan-Catalog.pdf";
            public const string StephenChurchCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Stephen-Church-Catalog.pdf";
            public const string SteveLeungCollection = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Steve-Leung-Catalog.pdf";
            public const string TAStudioFinishBrochure = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-Upholstery-Finishes.pdf";

            //add more on Aug 11, 2020
            public const string TAStudioHolliCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-Holli-Catalog.pdf";
            public const string TAStudioFrenzyCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/TA-Studio-Frenzy-Catalog.pdf";
            public const string TheOasisCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Oasis-Catalog.pdf";
            public const string TheIconicCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Iconic-Catalog.pdf";
            public const string TheGraceCatalog = "https://theodorealexander.sirv.com/website/Frontend/Live/assests/pdf/The-Grace-Catalog.pdf";
        }
    }
}
