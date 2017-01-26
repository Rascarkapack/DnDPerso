using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDPersoBLL.Base;
using DnDPersoEntities;
using DnDPersoEntities.Entities;
using DnDPersoDAL;

namespace DnDPersoBLL
{
    public class PersonnageBLL : BaseBLL<Personnage>
    {
        public static void SaveCharacterData(int idUser, int idCharacter, CharacterData model)
        {
            PersonnageDAL.SaveCharacterData(idUser, idCharacter, model);
        }

        public static CharacterData GetCharacterData(int idPersonnage)
        {
            return PersonnageDAL.GetCharacterData(idPersonnage);
        }
    }
}
