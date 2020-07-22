using System.Collections.Generic;
using Projeto_E_PLAYER;
using Projeto_E_PLAYER.Models;

namespace Projeto_E_PLAYER.interfaces
{
    public interface IEquipe
    {
        void Create( Equipe e);

        List<Equipe> ReadAll();

        void Update (Equipe e);

        void Delete(int IdEquipe);

    
        
    }
}