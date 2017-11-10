using JITSystem.DAL;

namespace JITSystem.BLL
{
    public class UpdateFromERPDB
    {
        public void UpdateFromERP()
        {
            T_StyleCodeInfoDAL StyleCodeInfodal = new T_StyleCodeInfoDAL();
            StyleCodeInfodal.UpdateFromERPDB();

        }
    }
}
