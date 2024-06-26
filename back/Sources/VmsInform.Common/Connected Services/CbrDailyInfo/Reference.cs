﻿//------------------------------------------------------------------------------
// <автоматически создаваемое>
//     Этот код создан программой.
//     //
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </автоматически создаваемое>
//------------------------------------------------------------------------------

namespace CbrDailyInfo
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://web.cbr.ru/", ConfigurationName="CbrDailyInfo.DailyInfoSoap")]
    internal interface DailyInfoSoap
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SaldoXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> SaldoXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/ROISfixXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> ROISfixXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/RuoniaXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> RuoniaXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/OstatDepoXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> OstatDepoXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/ValIntDayXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> ValIntDayXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/ValIntDay", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> ValIntDayAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/OstatDepo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> OstatDepoAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/ROISfix", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> ROISfixAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Ruonia", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> RuoniaAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/mrrf7D", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> mrrf7DAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/mrrf7DXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> mrrf7DXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/RepoDebtUSD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> RepoDebtUSDAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/RepoDebtUSDXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> RepoDebtUSDXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/mrrf", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> mrrfAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/mrrfXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> mrrfXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Saldo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SaldoAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/NewsInfoXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> NewsInfoXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/OmodInfoXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> OmodInfoXMLAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/XVol", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> XVolAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/XVolXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> XVolXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/MainInfoXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> MainInfoXMLAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/AllDataInfoXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> AllDataInfoXMLAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/NewsInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> NewsInfoAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapDayTotal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapDayTotalAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapDayTotalXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapDayTotalXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapDynamicXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapInfoSellUSDVolXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapInfoSellUSDVolXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapInfoSellUSDVol", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapInfoSellUSDVolAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapInfoSellUSD", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapInfoSellUSDAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapInfoSellUSDXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapInfoSellUSDXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/BiCurBaseXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> BiCurBaseXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/BiCurBase", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> BiCurBaseAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/BiCurBacketXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> BiCurBacketXMLAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/BiCurBacket", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> BiCurBacketAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapDynamic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapDynamicAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapMonthTotal", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapMonthTotalAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/SwapMonthTotalXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapMonthTotalXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/MKR", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> MKRAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/MKRXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> MKRXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/DV", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> DVAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/DVXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> DVXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Repo_debt", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> Repo_debtAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Repo_debtXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> Repo_debtXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Coins_base", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> Coins_baseAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Coins_baseXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> Coins_baseXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/FixingBase", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> FixingBaseAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/FixingBaseXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> FixingBaseXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Overnight", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> OvernightAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/OvernightXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> OvernightXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/Bauction", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> BauctionAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/BauctionXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> BauctionXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/DepoDynamicXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> DepoDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/DepoDynamic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> DepoDynamicAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/OstatDynamicXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> OstatDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/OstatDynamic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> OstatDynamicAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/DragMetDynamicXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> DragMetDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/DragMetDynamic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> DragMetDynamicAsync(System.DateTime fromDate, System.DateTime ToDate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetLatestDateTime", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.DateTime> GetLatestDateTimeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetLatestDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> GetLatestDateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetLatestDateTimeSeld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.DateTime> GetLatestDateTimeSeldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetLatestDateSeld", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<string> GetLatestDateSeldAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/EnumValutesXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> EnumValutesXMLAsync(bool Seld);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/EnumValutes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> EnumValutesAsync(bool Seld);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetLatestReutersDateTime", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.DateTime> GetLatestReutersDateTimeAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/EnumReutersValutesXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> EnumReutersValutesXMLAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/EnumReutersValutes", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> EnumReutersValutesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetReutersCursOnDateXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetReutersCursOnDateXMLAsync(System.DateTime On_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetReutersCursOnDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetReutersCursOnDateAsync(System.DateTime On_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetReutersCursDynamicXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetReutersCursDynamicXMLAsync(System.DateTime FromDate, System.DateTime ToDate, int NumCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetReutersCursDynamic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetReutersCursDynamicAsync(System.DateTime FromDate, System.DateTime ToDate, int NumCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetCursDynamicXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetCursDynamicXMLAsync(System.DateTime FromDate, System.DateTime ToDate, string ValutaCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetCursDynamic", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetCursDynamicAsync(System.DateTime FromDate, System.DateTime ToDate, string ValutaCode);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetCursOnDateXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetCursOnDateXMLAsync(System.DateTime On_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetSeldCursOnDateXML", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetSeldCursOnDateXMLAsync(System.DateTime On_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetSeldCursOnDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetSeldCursOnDateAsync(System.DateTime On_date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://web.cbr.ru/GetCursOnDate", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetCursOnDateAsync(System.DateTime On_date);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    internal interface DailyInfoSoapChannel : CbrDailyInfo.DailyInfoSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    internal partial class DailyInfoSoapClient : System.ServiceModel.ClientBase<CbrDailyInfo.DailyInfoSoap>, CbrDailyInfo.DailyInfoSoap
    {
        
    /// <summary>
    /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
    /// </summary>
    /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
    /// <param name="clientCredentials">Учетные данные клиента.</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DailyInfoSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(DailyInfoSoapClient.GetBindingForEndpoint(endpointConfiguration), DailyInfoSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DailyInfoSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DailyInfoSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DailyInfoSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DailyInfoSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DailyInfoSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> SaldoXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SaldoXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> ROISfixXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.ROISfixXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> RuoniaXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.RuoniaXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> OstatDepoXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.OstatDepoXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> ValIntDayXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.ValIntDayXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> ValIntDayAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.ValIntDayAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> OstatDepoAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.OstatDepoAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> ROISfixAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.ROISfixAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> RuoniaAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.RuoniaAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> mrrf7DAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.mrrf7DAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> mrrf7DXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.mrrf7DXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> RepoDebtUSDAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.RepoDebtUSDAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> RepoDebtUSDXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.RepoDebtUSDXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> mrrfAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.mrrfAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> mrrfXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.mrrfXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SaldoAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SaldoAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> NewsInfoXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.NewsInfoXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> OmodInfoXMLAsync()
        {
            return base.Channel.OmodInfoXMLAsync();
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> XVolAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.XVolAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> XVolXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.XVolXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> MainInfoXMLAsync()
        {
            return base.Channel.MainInfoXMLAsync();
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> AllDataInfoXMLAsync()
        {
            return base.Channel.AllDataInfoXMLAsync();
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> NewsInfoAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.NewsInfoAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapDayTotalAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapDayTotalAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapDayTotalXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapDayTotalXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapDynamicXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapInfoSellUSDVolXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapInfoSellUSDVolXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapInfoSellUSDVolAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapInfoSellUSDVolAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapInfoSellUSDAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapInfoSellUSDAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapInfoSellUSDXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapInfoSellUSDXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> BiCurBaseXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.BiCurBaseXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> BiCurBaseAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.BiCurBaseAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> BiCurBacketXMLAsync()
        {
            return base.Channel.BiCurBacketXMLAsync();
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> BiCurBacketAsync()
        {
            return base.Channel.BiCurBacketAsync();
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapDynamicAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapDynamicAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> SwapMonthTotalAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapMonthTotalAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> SwapMonthTotalXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.SwapMonthTotalXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> MKRAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.MKRAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> MKRXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.MKRXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> DVAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.DVAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> DVXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.DVXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> Repo_debtAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.Repo_debtAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> Repo_debtXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.Repo_debtXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> Coins_baseAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.Coins_baseAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> Coins_baseXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.Coins_baseXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> FixingBaseAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.FixingBaseAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> FixingBaseXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.FixingBaseXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> OvernightAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.OvernightAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> OvernightXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.OvernightXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> BauctionAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.BauctionAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> BauctionXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.BauctionXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> DepoDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.DepoDynamicXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> DepoDynamicAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.DepoDynamicAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> OstatDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.OstatDynamicXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> OstatDynamicAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.OstatDynamicAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> DragMetDynamicXMLAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.DragMetDynamicXMLAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> DragMetDynamicAsync(System.DateTime fromDate, System.DateTime ToDate)
        {
            return base.Channel.DragMetDynamicAsync(fromDate, ToDate);
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetLatestDateTimeAsync()
        {
            return base.Channel.GetLatestDateTimeAsync();
        }
        
        public System.Threading.Tasks.Task<string> GetLatestDateAsync()
        {
            return base.Channel.GetLatestDateAsync();
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetLatestDateTimeSeldAsync()
        {
            return base.Channel.GetLatestDateTimeSeldAsync();
        }
        
        public System.Threading.Tasks.Task<string> GetLatestDateSeldAsync()
        {
            return base.Channel.GetLatestDateSeldAsync();
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> EnumValutesXMLAsync(bool Seld)
        {
            return base.Channel.EnumValutesXMLAsync(Seld);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> EnumValutesAsync(bool Seld)
        {
            return base.Channel.EnumValutesAsync(Seld);
        }
        
        public System.Threading.Tasks.Task<System.DateTime> GetLatestReutersDateTimeAsync()
        {
            return base.Channel.GetLatestReutersDateTimeAsync();
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> EnumReutersValutesXMLAsync()
        {
            return base.Channel.EnumReutersValutesXMLAsync();
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> EnumReutersValutesAsync()
        {
            return base.Channel.EnumReutersValutesAsync();
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetReutersCursOnDateXMLAsync(System.DateTime On_date)
        {
            return base.Channel.GetReutersCursOnDateXMLAsync(On_date);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetReutersCursOnDateAsync(System.DateTime On_date)
        {
            return base.Channel.GetReutersCursOnDateAsync(On_date);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetReutersCursDynamicXMLAsync(System.DateTime FromDate, System.DateTime ToDate, int NumCode)
        {
            return base.Channel.GetReutersCursDynamicXMLAsync(FromDate, ToDate, NumCode);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetReutersCursDynamicAsync(System.DateTime FromDate, System.DateTime ToDate, int NumCode)
        {
            return base.Channel.GetReutersCursDynamicAsync(FromDate, ToDate, NumCode);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetCursDynamicXMLAsync(System.DateTime FromDate, System.DateTime ToDate, string ValutaCode)
        {
            return base.Channel.GetCursDynamicXMLAsync(FromDate, ToDate, ValutaCode);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetCursDynamicAsync(System.DateTime FromDate, System.DateTime ToDate, string ValutaCode)
        {
            return base.Channel.GetCursDynamicAsync(FromDate, ToDate, ValutaCode);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetCursOnDateXMLAsync(System.DateTime On_date)
        {
            return base.Channel.GetCursOnDateXMLAsync(On_date);
        }
        
        public System.Threading.Tasks.Task<System.Xml.Linq.XElement> GetSeldCursOnDateXMLAsync(System.DateTime On_date)
        {
            return base.Channel.GetSeldCursOnDateXMLAsync(On_date);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetSeldCursOnDateAsync(System.DateTime On_date)
        {
            return base.Channel.GetSeldCursOnDateAsync(On_date);
        }
        
        public System.Threading.Tasks.Task<CbrDailyInfo.ArrayOfXElement> GetCursOnDateAsync(System.DateTime On_date)
        {
            return base.Channel.GetCursOnDateAsync(On_date);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.DailyInfoSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.DailyInfoSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.DailyInfoSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.DailyInfoSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://www.cbr.ru/DailyInfoWebServ/DailyInfo.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            DailyInfoSoap,
            
            DailyInfoSoap12,
        }
    }
    
    [System.Xml.Serialization.XmlSchemaProviderAttribute(null, IsAny=true)]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class ArrayOfXElement : object, System.Xml.Serialization.IXmlSerializable
    {
        
        private System.Collections.Generic.List<System.Xml.Linq.XElement> nodesList = new System.Collections.Generic.List<System.Xml.Linq.XElement>();
        
        public ArrayOfXElement()
        {
        }
        
        public virtual System.Collections.Generic.List<System.Xml.Linq.XElement> Nodes
        {
            get
            {
                return this.nodesList;
            }
        }
        
        public virtual System.Xml.Schema.XmlSchema GetSchema()
        {
            throw new System.NotImplementedException();
        }
        
        public virtual void WriteXml(System.Xml.XmlWriter writer)
        {
            System.Collections.Generic.IEnumerator<System.Xml.Linq.XElement> e = nodesList.GetEnumerator();
            for (
            ; e.MoveNext(); 
            )
            {
                ((System.Xml.Serialization.IXmlSerializable)(e.Current)).WriteXml(writer);
            }
        }
        
        public virtual void ReadXml(System.Xml.XmlReader reader)
        {
            for (
            ; (reader.NodeType != System.Xml.XmlNodeType.EndElement); 
            )
            {
                if ((reader.NodeType == System.Xml.XmlNodeType.Element))
                {
                    System.Xml.Linq.XElement elem = new System.Xml.Linq.XElement("default");
                    ((System.Xml.Serialization.IXmlSerializable)(elem)).ReadXml(reader);
                    Nodes.Add(elem);
                }
                else
                {
                    reader.Skip();
                }
            }
        }
    }
}
