using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;

namespace Pokno.Model.Translator
{
    public class SettingTranslator : TranslatorBase<Setting, SETTING>
    {
        private ApplicationModeTranslator applicationModeTranslator;

        public SettingTranslator()
        {
            applicationModeTranslator = new ApplicationModeTranslator();
        }

        public override Setting TranslateToModel(SETTING entity)
        {
            try
            {
                Setting setting = null;
                if (entity != null)
                {
                    setting = new Setting();
                    setting.Id = (int)entity.Setting_Id;
                    setting.ApplicationDate = entity.Application_Date;
                    setting.ApplicationMode = applicationModeTranslator.Translate(entity.APPLICATION_MODE);
                    setting.IsCustomerLoyaltyEnabled = entity.Is_Customer_Loyalty_Enabled;
                    setting.IsActivated = entity.Is_Activated;
                    setting.ShowPackageRelationshipInStockSummaryReviewReport = entity.Show_Package_Relationship_In_Stock_Summary_Review_Report;
                }

                return setting;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override SETTING TranslateToEntity(Setting setting)
        {
            try
            {
                SETTING entity = null;
                if (setting != null)
                {
                    entity = new SETTING();
                    entity.Setting_Id = setting.Id;
                    entity.Application_Date = setting.ApplicationDate;
                    entity.Application_Mode_Id = setting.ApplicationMode.Id;
                    entity.Is_Customer_Loyalty_Enabled = setting.IsCustomerLoyaltyEnabled;
                    entity.Show_Package_Relationship_In_Stock_Summary_Review_Report = setting.ShowPackageRelationshipInStockSummaryReviewReport;
                    entity.Is_Activated = setting.IsActivated;
                    //entity.Db_Path = setting.DbPath;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }



    }


}
