using WSBackCityLending.dominio.modelos;

using System;
using WSBackCityLending.dominio.dto;

namespace WSBackCityLending.infraestructura.interfases
{
    public interface IServicioSeguridadInter
    {

        public Boolean autenticacion(SecurityUDtos datos);

        public String getRoles(String datos);

        public String getUserName(String datos);

        public Boolean logOut(String datos);

        public Ansewer   cambiarPassword(ChangePasswordDto datos);
    }
}
