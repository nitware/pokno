using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokno.Model.Translator
{
    public class TranslatorFactory
    {
        public static dynamic Create(string typeName)
        {
            try
            {
                typeName = typeName.Replace("_", "").ToLower();
                switch (typeName)
                {
                    case "bank":
                        {
                            return new BankTranslator();
                        }
                    //case "fee":
                    //    {
                    //        return new FeeTranslator();
                    //    }
                    //case "feetype":
                    //    {
                    //        return new FeeTypeTranslator();
                    //    }
                    //case "payment":
                    //    {
                    //        return new PaymentTranslator();
                    //    }
                    //case "school":
                    //    {
                    //        return new SchoolTranslator();
                    //    }
                    //case "student":
                    //    {
                    //        return new StudentTranslator();
                    //    }
                    //case "news":
                    //    {
                    //        return new NewsTranslator();
                    //    }
                    //case "quicklink":
                    //    {
                    //        return new QuickLinkTranslator();
                    //    }
                    //case "schoolbranch":
                    //    {
                    //        return new SchoolBranchTranslator();
                    //    }
                    //case "schoolphone":
                    //    {
                    //        return new SchoolPhoneTranslator();
                    //    }
                    //case "schoolbranchphone":
                    //    {
                    //        return new SchoolBranchPhoneTranslator();
                    //    }
                    //case "schooltype":
                    //    {
                    //        return new SchoolTypeTranslator();
                    //    }
                    //case "schoolcategory":
                    //    {
                    //        return new SchoolCategoryTranslator();
                    //    }
                    //case "state":
                    //    {
                    //        return new StateTranslator();
                    //    }
                    //case "sex":
                    //    {
                    //        return new SexTranslator();
                    //    }
                    //case "relationship":
                    //    {
                    //        return new RelationshipTranslator();
                    //    }
                    //case "occupation":
                    //    {
                    //        return new OccupationTranslator();
                    //    }
                    //case "studentcategory":
                    //    {
                    //        return new StudentCategoryTranslator();
                    //    }
                    //case "studenttype":
                    //    {
                    //        return new StudentTypeTranslator();
                    //    }
                    //case "studentstatus":
                    //    {
                    //        return new StudentStatusTranslator();
                    //    }
                    //case "level":
                    //    {
                    //        return new LevelTranslator();
                    //    }
                    //case "country":
                    //    {
                    //        return new CountryTranslator();
                    //    }
                    //case "illness":
                    //    {
                    //        return new IllnessTranslator();
                    //    }
                    //case "lga":
                    //case "localgovernment":
                    //    {
                    //        return new LGATranslator();
                    //    }
                    //case "subjectcategory":
                    //    {
                    //        return new SubjectCategoryTranslator();
                    //    }
                    //case "subjectcategoryoption":
                    //    {
                    //        return new SubjectCategoryOptionTranslator();
                    //    }
                    //case "subjectcategoryoptionassignment":
                    //    {
                    //        return new SubjectCategoryOptionAssignmentTranslator();
                    //    }
                    //case "levelsubjectcategory":
                    //    {
                    //        return new LevelSubjectCategoryTranslator();
                    //    }
                    //case "studentlevel":
                    //    {
                    //        return new StudentLevelTranslator();
                    //    }
                    //case "sessionterm":
                    //    {
                    //        return new SessionTermTranslator();
                    //    }
                    //case "currentsessionterm":
                    //    {
                    //        return new CurrentSessionTermTranslator();
                    //    }
                    //case "studentcurrentlevel":
                    //    {
                    //        return new StudentCurrentLevelTranslator();
                    //    }
                    //case "feedetail":
                    //    {
                    //        return new FeeDetailTranslator();
                    //    }
                    //case "paymentcard":
                    //    {
                    //        return new PaymentCardTranslator();
                    //    }
                    //case "paymentweb":
                    //    {
                    //        return new PaymentWebTranslator();
                    //    }
                    //case "session":
                    //    {
                    //        return new SessionTranslator();
                    //    }
                    //case "paymenttype":
                    //    {
                    //        return new PaymentTypeTranslator();
                    //    }
                    //case "paymentmode":
                    //    {
                    //        return new PaymentModeTranslator();
                    //    }
                    //case "paymentchannel":
                    //    {
                    //        return new PaymentChannelTranslator();
                    //    }

                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }



}
