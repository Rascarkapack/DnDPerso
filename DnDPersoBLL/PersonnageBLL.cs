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
        public static bool SaveCharacterData(string idCharacter, CharacterData model)
        {
            return PersonnageDAL.SaveCharacterData(idCharacter, model);
        }
    }
}
