using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using System.Collections.Generic;
using System.Collections;
using Server.Misc;
namespace Server.Mobiles
{
    public class VitaviRenowned : BaseRenowned
	{
		public override Type[] UniqueSAList{ get { return new Type[] {typeof( Fur ) }; } }

        public override Type[] SharedSAList{ get {return new Type[] {typeof( AxeOfAbandon ),typeof( DemonBridleRing ), typeof( VoidInfusedKilt ) }; } }

        public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public VitaviRenowned() : base( AIType.AI_Mage )
		{
			Name = "Vitavi";
			Title = "[Renowned]";
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 300, 350 );
			SetDex( 250, 300 );
			SetInt( 300, 350 );

			SetHits( 45000, 50000 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 60 );
			SetResistance( ResistanceType.Fire, 30, 50 );
			SetResistance( ResistanceType.Cold, 60, 80 );
			SetResistance( ResistanceType.Poison, 20, 30 );
			SetResistance( ResistanceType.Energy, 30, 40 );

			SetSkill( SkillName.EvalInt, 70.1, 80.0 );
			SetSkill( SkillName.Magery, 70.1, 80.0 );
			SetSkill( SkillName.MagicResist, 75.1, 100.0 );
			SetSkill( SkillName.Tactics, 70.1, 75.0 );
			SetSkill( SkillName.Wrestling, 50.1, 75.0 );

			Fame = 7500;
			Karma = -7500;

			VirtualArmor = 44;

                        PackItem( new EssenceBalance() );

			PackReg( 6 );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.LowScrolls );
		}
		
		

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public VitaviRenowned( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( Body == 42 )
			{
				Body = 0x8F;
				Hue = 0;
			}
		}
	}
}
