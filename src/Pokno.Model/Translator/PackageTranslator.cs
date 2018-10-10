using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Pokno.Entity;

namespace Pokno.Model
{
    public class PackageTranslator : TranslatorBase<Package, PACKAGE>
    {

        public override Package TranslateToModel(PACKAGE packageEntity)
        {
            try
            {
                Package package = null;
                if (packageEntity != null)
                {
                    package = new Package();
                    package.Id = (int)packageEntity.Package_Id;
                    package.Name = packageEntity.Package_Name;
                    package.Description = packageEntity.Package_Description;

                }
                return package;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override PACKAGE TranslateToEntity(Package package)
        {
            try
            {
                PACKAGE packageEntity = null;
                if (package != null)
                {
                    packageEntity = new PACKAGE();
                    packageEntity.Package_Id = package.Id;
                    packageEntity.Package_Name = package.Name;
                    packageEntity.Package_Description = package.Description;

                }
                return packageEntity;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
