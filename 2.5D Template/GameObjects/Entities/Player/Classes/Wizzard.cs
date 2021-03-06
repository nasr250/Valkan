﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Wizzard : Player
{
    protected override void LoadStats()
    {
        playerType = PlayerType.Wizzard;

        speed = 300;
        maxhealth = 60;
        MaxStamina = 120;
        staminatimerreset = 0.75f;
        addstaminatimerreset = 0.02f;
    }

    protected override void LoadSkills()
    {
        skill1 = new ProjectileAttack("Sprites/Menu/Skills/spr_skill_6", "Sprites/Items/Projectiles/spr_ice_", 8, "Sprites/Items/Particles/spr_ice_explosion@4");
        skill2 = new ProjectileAttack("Sprites/Menu/Skills/spr_skill_7", "Sprites/Items/Projectiles/spr_fire_", 8, "Sprites/Items/Particles/spr_fire_explosion@3x4", 1.5f, 12, MouseButton.Right);
        skill3 = new BlockHold("Sprites/Menu/Skills/spr_skill_8", "Sprites/Items/Particles/spr_shield@4");
    }
}

