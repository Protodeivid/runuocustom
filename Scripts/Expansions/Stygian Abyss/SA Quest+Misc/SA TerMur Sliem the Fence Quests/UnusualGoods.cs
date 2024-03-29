/*                                                             .---.
                                                              /  .  \
                                                             |\_/|   |
                                                             |   |  /|
  .----------------------------------------------------------------' |
 /  .-.                                                              |
|  /   \         Contribute To The Orbsydia SA Project               |
| |\_.  |                                                            |
|\|  | /|                        By Lotar84                          |
| `---' |                                                            |
|       |       (Orbanised by Orb SA Core Development Team)          | 
|       |                                                           /
|       |----------------------------------------------------------'
\       |
 \     /
  `---'
*/
using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Engines.Quests
{
    public class UnusualGoods : BaseQuest
    {
        /*Unusual Goods*/
        public override object Title { get { return 1113787; } }

        /*Psst. Do you want to buy something rare and valuable? Yes? Good. I have in my possession an imbuing ingredient that is highly sought after. 
          If you wish to make a trade, it will not come cheaply. 
          Provide me with two perfect emeralds and one piece of crystalline blackrock, and what is in this box shall be yours. */
        public override object Description { get { return 1113788; } }

        /*It is your choice, but do not speak of this to anyone else.*/
        public override object Refuse { get { return 1113789; } }

        /*In exchange for this bag, I want two perfect emeralds and one piece of crystalline blackrock. Nothing more, nothing less.*/
        public override object Uncomplete { get { return 1113790; } }

        public UnusualGoods()
            : base()
        {
            AddObjective(new ObtainObjective(typeof(PerfectEmerald), "Perfect Emerald", 2, 0x3194));

            AddObjective(new ObtainObjective(typeof(CrystallineBlackrock), "Crystalline Blackrock", 1, 0x5732));

            AddReward(new BaseReward(typeof(EssenceBox), "Essence Box"));
        }

        /*Let me see what you have brought me. Yes, this is of fine quality, and I accept it in trade. 
          Here is your box. Please do not spread word of our deal, as I do not want attention brought upon me. I am sure you understand.*/
        public override object Complete { get { return 1113791; } }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}