using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace WkBackOfficeTests.Support
{
    public static class CsvReaderClass
    {

        // Reads the data from Cuctomers csv File
        public static IEnumerable<CustomerCsvHeaders> ReadCustomerCsv(string filepath)
        {
            bool exists = File.Exists(filepath);
            if (!exists)
            {
                throw new Exception("File not exists or incorrect file name");
            }
            else
            {
                var file = new StreamReader(filepath);
                var reader = new CsvReader(file);
                return reader.GetRecords<CustomerCsvHeaders>().ToList();
            }
        }


        // Reads the Data from Subscriptions csv File 
        public static IEnumerable<SubscriptionCsvHeaders> ReadSubscriptionCsv(string filepath)
        {
            bool exists = File.Exists(filepath);
            if (!exists)
            {
                throw new Exception("File not exists or incorrect file name");
            }
            else
            {
                var file = new StreamReader(filepath);
                var reader = new CsvReader(file);
                return reader.GetRecords<SubscriptionCsvHeaders>().ToList();
            }
        }
    }


    public class CustomerCsvHeaders
    {

        public string CR_BP_TYPE { set; get; }
        public string CR_SHIPTO_ID { set; get; }
        public string CR_TITLE { set; get; }
        public string FIRSTNAME { set; get; }
        public string LASTNAME { set; get; }
        public string EMAIL { set; get; }
        public string BUS_PHONE { set; get; }
        public string FAX { set; get; }
        public string COMPANY_NAME { set; get; }
        public string AD_CARE_OF { set; get; }
        public string ADDRESS { set; get; }
        public string ADDRESS_2 { set; get; }
        public string ADDRESS_3 { set; get; }
        public string CITY { set; get; }
        public string STATE { set; get; }
        public string COUNTRY { set; get; }
        public string ZIP { set; get; }
        public string JOB_TITLE { set; get; }
        public string ACADEMIC_TITLE_1 { set; get; }
        public string ACADEMIC_TITLE_2 { set; get; }
        public string NAME_SUPPLEMENT { set; get; }
        public string DO_NOT_CALL { set; get; }
        public string CREATE_DATE { set; get; }
        public string CREATE_TIME { set; get; }
        public string ACTION { set; get; }
    }

    public class SubscriptionCsvHeaders
    {

        public string CR_SHIPTO_ID { set; get; }
        public string CR_BILLTO_ID { set; get; }
        public string CR_PAYER_ID { set; get; }
        public string CR_SOLDTO_ID { set; get; }
        public string SUBS_NO { set; get; }
        public string ITEM_NUMBER { set; get; }
        public string PACKAGE_CODE { set; get; }
        public string CR_BOM_CODE { set; get; }
        public string CR_BOM_TITLE { set; get; }
        public string CR_MEDIA_TYPE { set; get; }
        public string USER_COUNT { set; get; }
        public string SUB_CRE_DATE { set; get; }
        public string END_DATE { set; get; }
        public string INV_DATE { set; get; }
        public string PREVIOUS_SUBS { set; get; }
        public string RENEW_NO { set; get; }
        public string BV_ORDER_ID { set; get; }
        public string BILLING_BLOCK { set; get; }
        public string HDR_DELIVERY_BLOCK { set; get; }
        public string CR_CONTRACT_TYPE { set; get; }
        public string REJECTION { set; get; }
        public string CANCELLATION { set; get; }

    }




}