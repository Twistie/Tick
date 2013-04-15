using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tick.typeClasses;

namespace Tick
{
    public interface ISaveLoad
    {
        void StartSave();
        void EndSave();

        void StartEntity(Entity e, bool isChar );
        void EndEntity();

        void StartChar(Character c);
        void EndChar();
        List<Character> LoadChars();

        void StartArea(int x, int y);
        void EndArea();
    }
}
