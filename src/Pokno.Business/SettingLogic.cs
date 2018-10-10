using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pokno.Entity;
using Pokno.Model.Model;
using Pokno.Business.Interfaces;
using Pokno.Model.Translator;
using System.Linq.Expressions;
using System.Data.Entity.Core;

namespace Pokno.Business
{
    public class SettingLogic : BusinessLogicBase<Setting, SETTING>
    {
        public SettingLogic(IRepository repository) : base(repository)
        {
            OpenDatabaseConnectionIfClosed();
            translator = new SettingTranslator();
        }

        public Setting Get()
        {
            try
            {
                Setting setting = null;
                List<Setting> settings = base.GetAll();
                if (settings != null && settings.Count > 1)
                {
                    throw new Exception("Multiple instances of setting found! Please contact your system administrator.");
                }
                else if (settings.Count == 1)
                {
                    setting = settings.SingleOrDefault();
                }

                return setting;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override Setting Add(Setting setting)
        {
            try
            {
                if (setting == null)
                {
                    throw new ArgumentNullException("setting");
                }

                if (setting.IsDefaultDb)
                {
                    setting.DbPath = null;
                }

                Setting newSetting = null;
                if (setting.Id <= 0)
                {
                    setting.Id = 1;
                    newSetting = base.Add(setting);
                }
                else
                {
                    if (Modify(setting))
                    {
                        newSetting = setting;
                    }
                }

                return newSetting;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Modify(Setting setting)
        {
            try
            {
                Expression<Func<SETTING, bool>> predicate = s => s.Setting_Id == setting.Id;
                SETTING entity = GetEntityBy(predicate);

                entity.Application_Date = setting.ApplicationDate;
                entity.Application_Mode_Id = setting.ApplicationMode.Id;
                entity.Is_Customer_Loyalty_Enabled = setting.IsCustomerLoyaltyEnabled;
                entity.Show_Package_Relationship_In_Stock_Summary_Review_Report = setting.ShowPackageRelationshipInStockSummaryReviewReport;
                entity.Is_Activated = setting.IsActivated;
                //entity.Db_Path = setting.DbPath;

                int rowsAffected = repository.Save();
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    throw new Exception(NoItemModified);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException(ArgumentNullException);
            }
            catch (UpdateException)
            {
                throw new UpdateException(UpdateException);
            }
            catch (Exception)
            {
                throw;
            }
        }


        


    }

}
