using System;
using Alexandria.ItemAPI;
using UnityEngine;

namespace NevernamedsItems;

internal class DemoterBullets : PassiveItem
{
	public static void Init()
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		PickupObject val = ItemSetup.NewItem<DemoterBullets>("Demoter Bullets", "You're Fired!", "Chance to downgrade enemies into a less powerful form.\n\nBusiness is Business, and Business is universal. The Gungeon is no exception. It's unfortunate, but those not up to the Gungeon's rigorous standards may have to be... fired.\n\nDemoter? I hardly even know her!", "demoterbullets_icon", assetbundle: true);
		val.quality = (ItemQuality)2;
		AlexandriaTags.SetTag(val, "bullet_modifier");
		Doug.AddToLootPool(val.PickupObjectId);
	}

	public void onFired(Projectile bullet, float eventchancescaler)
	{
		if (Random.value < 0.3f)
		{
			bullet.OnHitEnemy = (Action<Projectile, SpeculativeRigidbody, bool>)Delegate.Combine(bullet.OnHitEnemy, new Action<Projectile, SpeculativeRigidbody, bool>(onHitEnemy));
		}
	}

	public void onHitEnemy(Projectile bullet, SpeculativeRigidbody enemy, bool fatal)
	{
		//IL_0d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0b: Expected O, but got Unknown
		if (!fatal)
		{
			string text = null;
			switch (((BraveBehaviour)enemy).aiActor.EnemyGuid)
			{
			case "db35531e66ce41cbb81d507a34366dfe":
			case "88b6b6a93d4b4234a67844ef4728382c":
			case "70216cae6c1346309d86d4a0b4603045":
			case "df7fb62405dc4697b7721862c7b6b3cd":
			case "3cadf10c489b461f9fb8814abc1a09c1":
			case "8bb5578fba374e8aae8e10b754e61d62":
			case "e5cffcfabfae489da61062ea20539887":
			case "1a78cfb776f54641b832e92c44021cf2":
			case "d4a9836f8ab14f3fadd0f597438b1f1f":
			case "c4cf0620f71c4678bb8d77929fd4feff":
			case "47bdfec22e8e4568a619130a267eab5b":
			case "05cb719e0178478685dc610f8b3e8bfc":
				text = "01972dee89fc4404a5c408d50007dad5";
				break;
			case "43426a2e39584871b287ac31df04b544":
				text = "8bb5578fba374e8aae8e10b754e61d62";
				break;
			case "b54d89f9e802455cbb2b8a96a31e8259":
			case "7f665bd7151347e298e4d366f8818284":
			case "ddf12a4881eb43cfba04f36dd6377abb":
				text = "128db2f0781141bcb505d8f00f9e4d47";
				break;
			case "2752019b770f473193b08b4005dc781f":
			case "1bd8e49f93614e76b140077ff2e33f2b":
			case "b1770e0f1c744d9d887cc16122882b4f":
				text = "b54d89f9e802455cbb2b8a96a31e8259";
				break;
			case "044a9f39712f456597b9762893fbc19c":
				text = "2752019b770f473193b08b4005dc781f";
				break;
			case "5288e86d20184fa69c91ceb642d31474":
			case "95ec774b5a75467a9ab05fa230c0c143":
				text = "336190e29e8a4f75ab7486595b700d4a";
				break;
			case "e61cab252cfb435db9172adc96ded75f":
			case "022d7c822bc146b58fe3b0287568aaa2":
			case "ccf6d241dad64d989cbcaca2a8477f01":
			case "062b9b64371e46e195de17b6f10e47c8":
			case "116d09c26e624bca8cca09fc69c714b3":
			case "864ea5a6a9324efc95a0dd2407f42810":
				text = "0239c0680f9f467dbe5c4aab7dd1eca6";
				break;
			case "fe3fe59d867347839824d5d9ae87f244":
			case "0239c0680f9f467dbe5c4aab7dd1eca6":
				text = "042edb1dfb614dc385d5ad1b010f2ee3";
				break;
			case "b8103805af174924b578c98e95313074":
			case "042edb1dfb614dc385d5ad1b010f2ee3":
				text = "42be66373a3d4d89b91a35c9ff8adfec";
				break;
			case "0b547ac6b6fc4d68876a241a88f5ca6a":
			case "1bc2a07ef87741be90c37096910843ab":
				text = "864ea5a6a9324efc95a0dd2407f42810";
				break;
			case "9b2cf2949a894599917d4d391a0b7394":
			case "56fb939a434140308b8f257f0f447829":
				text = "c4fba8def15e47b297865b18e36cbef8";
				break;
			case "c4fba8def15e47b297865b18e36cbef8":
				text = "206405acad4d4c33aac6717d184dc8d4";
				break;
			case "6f22935656c54ccfb89fca30ad663a64":
			case "a400523e535f41ac80a43ff6b06dc0bf":
			case "216fd3dfb9da439d9bd7ba53e1c76462":
			case "78e0951b097b46d89356f004dda27c42":
				text = "c0ff3744760c4a2eb0bb52ac162056e6";
				break;
			case "c50a862d19fc4d30baeba54795e8cb93":
			case "b1540990a4f1480bbcb3bea70d67f60d":
			case "8b4a938cdbc64e64822e841e482ba3d2":
				text = "cf2b7021eac44e3f95af07db9a7c442c";
				break;
			case "ba657723b2904aa79f9e51bce7d23872":
				text = "8b4a938cdbc64e64822e841e482ba3d2";
				break;
			case "d8a445ea4d944cc1b55a40f22821ae69":
				text = "ffdc8680bdaa487f8f31995539f74265";
				break;
			case "98fdf153a4dd4d51bf0bafe43f3c77ff":
				text = "6b7ef9e5d05b4f96b04f05ef4a0d1b18";
				break;
			case "844657ad68894a4facb1b8e1aef1abf9":
				text = "f020570a42164e2699dcf57cac8a495c";
				break;
			case "ed37fa13e0fa4fcf8239643957c51293":
			case "4b21a913e8c54056bc05cafecf9da880":
				text = "76bc43539fc24648bff4568c75c686d1";
				break;
			case "8a9e9bedac014a829a48735da6daf3da":
				text = "6e972cd3b11e4b429b888b488e308551";
				break;
			case "c5b11bfc065d417b9c4d03a5e385fe2c":
				text = "c5b11bfc065d417b9c4d03a5e385fe2c";
				break;
			case "b70cbd875fea498aa7fd14b970248920":
				text = "72d2f44431da43b8a3bae7d8a114a46d";
				break;
			case "1cec0cdf383e42b19920787798353e46":
				text = "af84951206324e349e1f13f9b7b60c1a";
				break;
			case "af84951206324e349e1f13f9b7b60c1a":
				text = "c2f902b7cbe745efb3db4399927eab34";
				break;
			case "eed5addcc15148179f300cc0d9ee7f94":
				text = "f905765488874846b7ff257ff81d6d0c";
				break;
			case "c0260c286c8d4538a697c5bf24976ccf":
			case "19b420dec96d4e9ea4aebc3398c0ba7a":
				text = "4d37ce3d666b4ddda8039929225b7ede";
				break;
			case "5f15093e6f684f4fb09d3e7e697216b4":
				text = "c0260c286c8d4538a697c5bf24976ccf";
				break;
			case "33b212b856b74ff09252bf4f2e8b8c57":
				text = "f155fd2759764f4a9217db29dd21b7eb";
				break;
			case "3f2026dc3712490289c4658a2ba4a24b":
			case "ba928393c8ed47819c2c5f593100a5bc":
				text = "33b212b856b74ff09252bf4f2e8b8c57";
				break;
			case "56f5a0f2c1fc4bc78875aea617ee31ac":
				text = "4db03291a12144d69fe940d5a01de376";
				break;
			case "e861e59012954ab2b9b6977da85cb83c":
				text = "1386da0f42fb4bcabc5be8feb16a7c38";
				break;
			case "463d16121f884984abe759de38418e48":
			case "383175a55879441d90933b5c4e60cf6f":
				text = "ec8ea75b557d4e7b8ceeaacdf6f8238c";
				break;
			case "7ec3e8146f634c559a7d58b19191cd43":
			case "1a4872dafdb34fd29fe8ac90bd2cea67":
				text = "2feb50a6a40f4f50982e89fd276f6f15";
				break;
			case "981d358ffc69419bac918ca1bdf0c7f7":
				text = "1a4872dafdb34fd29fe8ac90bd2cea67";
				break;
			case "1f290ea06a4c416cabc52d6b3cf47266":
				text = "906d71ccc1934c02a6f4ff2e9c07c9ec";
				break;
			case "df4e9fedb8764b5a876517431ca67b86":
				text = "9eba44a0ea6c4ea386ff02286dd0e6bd";
				break;
			}
			if (((BraveBehaviour)enemy).aiActor.IsTransmogrified)
			{
				((BraveBehaviour)enemy).aiActor.IsTransmogrified = false;
			}
			if (text != null)
			{
				SpecialTransmogrify(((BraveBehaviour)enemy).aiActor, EnemyDatabase.GetOrLoadByGuid(text), (GameObject)ResourceCache.Acquire("Global VFX/VFX_Item_Spawn_Poof"));
			}
		}
	}

	public void SpecialTransmogrify(AIActor InputEnemy, AIActor OutputEnemy, GameObject EffectVFX)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		if ((InputEnemy.IsTransmogrified && ((GameActor)InputEnemy).ActorName == ((GameActor)OutputEnemy).ActorName) || InputEnemy.IsMimicEnemy || !Object.op_Implicit((Object)(object)((BraveBehaviour)InputEnemy).healthHaver) || ((BraveBehaviour)InputEnemy).healthHaver.IsBoss || InputEnemy.ParentRoom == null)
		{
			return;
		}
		Vector2 centerPosition = ((GameActor)InputEnemy).CenterPosition;
		float currentHealthPercentage = ((BraveBehaviour)InputEnemy).healthHaver.GetCurrentHealthPercentage();
		if ((Object)(object)EffectVFX != (Object)null)
		{
			SpawnManager.SpawnVFX(EffectVFX, Vector2.op_Implicit(centerPosition), Quaternion.identity);
		}
		AIActor val = AIActor.Spawn(OutputEnemy, Vector2Extensions.ToIntVector2(centerPosition, (VectorConversions)0), InputEnemy.ParentRoom, true, (AwakenAnimationType)0, true);
		if (Object.op_Implicit((Object)(object)val))
		{
			val.IsTransmogrified = true;
			float currentHealth = ((BraveBehaviour)val).healthHaver.GetCurrentHealth();
			float num = (currentHealth *= currentHealthPercentage);
			((BraveBehaviour)val).healthHaver.ForceSetCurrentHealth(num);
			if (((BraveBehaviour)val).healthHaver.GetCurrentHealth() <= 0f)
			{
				((BraveBehaviour)val).healthHaver.ApplyDamage(100000f, Vector2.zero, "Demoted To Corpse", (CoreDamageTypes)0, (DamageCategory)0, false, (PixelCollider)null, false);
			}
		}
		AkSoundEngine.PostEvent("Play_ENM_wizardred_appear_01", ((Component)this).gameObject);
		InputEnemy.EraseFromExistenceWithRewards(false);
	}

	public override void Pickup(PlayerController player)
	{
		player.PostProcessProjectile += onFired;
		((PassiveItem)this).Pickup(player);
	}

	public override DebrisObject Drop(PlayerController player)
	{
		DebrisObject result = ((PassiveItem)this).Drop(player);
		player.PostProcessProjectile -= onFired;
		return result;
	}
}
