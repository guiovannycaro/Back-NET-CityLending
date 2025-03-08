using WSBackCityLending.dominio.modelos;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface IDepartmentInter
    {
        List<Department> returnAll();
        public Department searchRecordById(int id);
        public String addRecord(Department datos);
        public String updateRecord(Department datos);

        public String dropRecord(int id);

        public Department searchRecordByName(Department datos);
    }
}
