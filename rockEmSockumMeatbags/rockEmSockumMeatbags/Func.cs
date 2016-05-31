using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace rockEmSockumMeatbags
{
    class Func
    {
        public static void safeDraw(SpriteBatch spriteBatch, Action f)
        {
            spriteBatch.Begin();
            f();
            spriteBatch.End();
        }
    }
}
