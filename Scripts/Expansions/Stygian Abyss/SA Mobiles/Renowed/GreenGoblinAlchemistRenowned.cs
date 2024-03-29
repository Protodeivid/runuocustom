using System;
using Server;
using Server.Items;
using Server.Spells;
using Server.Spells.Seventh;
using Server.Spells.Fifth;
using Server.Engines.CannedEvil;
using System.Collections.Generic;
using System.Collections;
using Server.Misc;
using Server.Targeting;

namespace Server.Mobiles
{
    public class GreenGoblinAlchemistRenowned : BaseRenowned
	{


        public override Type[] UniqueSAList { get { return new Type[] { typeof(ObsidianEarrings), typeof(TheImpalersPick) }; } }

        public override Type[] SharedSAList{ get { return new Type[] { typeof( RelicFragment )}; } }

        
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Orc; } }

		[Constructable]
		public GreenGoblinAlchemistRenowned() : base( AIType.AI_Melee )
		{
			Name = "Green Goblin Alchemist";
			Title = "[Renowned]";
			Body = 42;
			BaseSoundID = 437;

			SetStr( 600, 650 );
			SetDex( 50, 70 );
			SetInt( 100, 250 );

			SetHits( 1000, 1500 );

			SetDamage( 5, 7 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50, 55 );
			SetResistance( ResistanceType.Fire, 55, 60 );
			SetResistance( ResistanceType.Cold, 40, 50 );
			SetResistance( ResistanceType.Poison, 40, 50 );
			SetResistance( ResistanceType.Energy, 20, 25 );

			SetSkill( SkillName.MagicResist, 120.0, 125.0 );
			SetSkill( SkillName.Tactics, 95.0, 100.0 );
			SetSkill( SkillName.Wrestling, 100.0, 110.0 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;
			
                        PackItem( new EssenceControl() );

			switch ( Utility.Random( 20 ) )
			{
				case 0: PackItem( new Scimitar() ); break;
				case 1: PackItem( new Katana() ); break;
				case 2: PackItem( new WarMace() ); break;
				case 3: PackItem( new WarHammer() ); break;
				case 4: PackItem( new Kryss() ); break;
				case 5: PackItem( new Pitchfork() ); break;
			}

			PackItem( new ThighBoots() );

			switch ( Utility.Random( 3 ) )
			{
				case 0: PackItem( new Ribs() ); break;
				case 1: PackItem( new Shaft() ); break;
				case 2: PackItem( new Candle() ); break;
			}

			if ( 0.2 > Utility.RandomDouble() )
				PackItem( new BolaBall() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
			// TODO: weapon, misc
		}
		
		
		
		public GreenGoblinAlchemistRenowned( Serial serial ) : base( serial )
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
		}
	}
}