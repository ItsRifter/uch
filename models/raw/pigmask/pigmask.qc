// Created by Crowbar 0.71

$modelname "uch\pigmask.mdl"

$bodygroup "studio"
{
	blank
	studio "PigMask.smd"
}
$bodygroup "badges"
{
	blank
	studio "goldbadge.smd"
	studio "badges.smd"
}
$bodygroup "cape"
{
	blank
	studio "cape.smd"
}
$bodygroup "studio"
{
	studio "PigMask_2.smd"
}


$surfaceprop "flesh"

$contents "solid"

$illumposition 5 -3 0 "Body1"

$eyeposition 0 0 75.85

$opaque

$cdmaterials "models\uch\PigMask\"

$texturegroup "skinfamilies"
{
	{ "PigMask"        }
	{ "PigMaskCaptain" }
	{ "PigMaskMajor"   }
	{ "PigMaskColonel" }
}

$attachment "eyes" "Head" 5 -15 0 rotate 0 -90 -90
$attachment "forward" "Head" 5 -15 0 rotate 0 -90 -90
$attachment "anim_attachment_RH" "Head" 15 -12 12 rotate 0 -95 -90

$cbox 0 0 0 0 0 0

$bbox -36.196 -28.535 -8.129 19.195 28.442 68.509

$definebone "Body1" "" 0 3.497332 19.130562 -89.999982 0 0 0 0 0 0 0 0
$definebone "Body2" "Body1" 2.078949 0 0 0 9.17019 0 0 0 0 0 0 0
$definebone "Head" "Body2" 14.966526 -4.087239 0 0 -9.784859 -0.000057 0 0 0 0 0 0
$definebone "Snout" "Head" 6.533012 -9.083206 0 0.000057 -117.244924 0 0 0 0 0 0 0
$definebone "Rarm_1" "Body2" 10.045073 -4.025765 14.409141 -89.999982 80.830194 0 0 0 0 0 0 0
$definebone "Rarm_2" "Rarm_1" 6.291939 -0.386637 0.883984 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Hand" "Rarm_2" 7.827745 -0.171841 -1.22791 0 -0.000172 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger4" "ValveBiped.Bip01_R_Hand" 5.170649 -1.367004 -2.878075 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger41" "ValveBiped.Bip01_R_Finger4" -2.788147 0 -0.000001 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger3" "ValveBiped.Bip01_R_Hand" 5.427561 -1.855049 -1.063511 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger31" "ValveBiped.Bip01_R_Finger3" -3.063927 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger2" "ValveBiped.Bip01_R_Hand" 5.399355 -1.85503 0.809667 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger21" "ValveBiped.Bip01_R_Finger2" -3.224022 0 0.000092 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger1" "ValveBiped.Bip01_R_Hand" 5.421816 -1.551682 2.72703 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger11" "ValveBiped.Bip01_R_Finger1" -3.160519 0.000008 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger0" "ValveBiped.Bip01_R_Hand" 2.074726 1.364342 2.491039 0.000036 -179.999827 -179.999595 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_R_Finger01" "ValveBiped.Bip01_R_Finger0" -3.120808 -0.033237 -1.597446 0 0 0 0 0 0 0 0 0
$definebone "Larm_01" "Body2" 10.045057 -4.025765 -14.409282 -89.999982 -99.169771 0 0 0 0 0 0 0
$definebone "Larm_02" "Larm_01" -6.291931 0.386633 -0.883984 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Hand" "Larm_02" -7.827747 0.171841 1.22791 0 -0.000172 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger0" "ValveBiped.Bip01_L_Hand" -2.074583 -1.364347 -2.49103 -0.000036 -179.999827 -179.999595 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger01" "ValveBiped.Bip01_L_Finger0" 3.1208 0.033243 1.597447 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger1" "ValveBiped.Bip01_L_Hand" -5.42168 1.551678 -2.727026 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger11" "ValveBiped.Bip01_L_Finger1" 3.160519 -0.000004 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger2" "ValveBiped.Bip01_L_Hand" -5.399212 1.85503 -0.809663 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger21" "ValveBiped.Bip01_L_Finger2" 3.224022 -0.000004 -0.000092 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger3" "ValveBiped.Bip01_L_Hand" -5.427418 1.855049 1.063515 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger31" "ValveBiped.Bip01_L_Finger3" 3.063927 0 0 0 0 0 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger4" "ValveBiped.Bip01_L_Hand" -5.170509 1.367008 2.878081 -0.000036 -179.999827 -179.999199 0 0 0 0 0 0
$definebone "ValveBiped.Bip01_L_Finger41" "ValveBiped.Bip01_L_Finger4" 2.788147 0 -0.000001 0 0 0 0 0 0 0 0 0
$definebone "Rleg1" "Body1" -3.784245 -2.31582 7.518579 -5.806698 -179.999964 -89.999982 0 0 0 0 0 0
$definebone "Rleg2" "Rleg1" 6.340658 -0.004251 0.028369 0 0.203973 89.999982 0 0 0 0 0 0
$definebone "Rfoot" "Rleg2" 2.961283 -0.000001 0.029165 0.000058 49.398643 0 0 0 0 0 0 0
$definebone "Rtoe" "Rfoot" 6.894002 0.067572 -0.012426 0.059473 39.994852 5.602439 0 0 0 0 0 0
$definebone "Lleg1" "Body1" -3.784247 -2.31582 -7.518721 -5.806698 0 -89.999982 0 0 0 0 0 0
$definebone "Lleg2" "Lleg1" -6.340661 0.004254 -0.028369 0 0.203973 89.999982 0 0 0 0 0 0
$definebone "Lfoot" "Lleg2" -2.961286 0.000001 -0.029165 0.000058 49.39864 0 0 0 0 0 0 0
$definebone "Ltoe" "Lfoot" -6.894004 -0.067572 0.012429 0.059473 39.994852 5.602439 0 0 0 0 0 0
$definebone "Cape_M1" "Body2" 17.741219 5.954057 0.000007 0 136.542954 0 0 0 0 0 0 0
$definebone "Cape_M2" "Cape_M1" 7.211996 0.000002 0 0 25.634364 0 0 0 0 0 0 0
$definebone "Cape_M3" "Cape_M2" 8.401733 -0.000008 0 0 6.98424 0 0 0 0 0 0 0
$definebone "Cape_L1" "Body2" 14.615833 1.249217 -13.371202 -16.498778 -48.60378 -19.051249 0 0 0 0 0 0
$definebone "Cape_L2" "Cape_L1" -6.583296 -0.000034 -0.000001 0.000001 29.620485 0.000003 0 0 0 0 0 0
$definebone "Cape_L3" "Cape_L2" -7.863504 0.000002 0 0 8.621011 0.000002 0 0 0 0 0 0
$definebone "capedummy" "Body2" 14.783909 1.146537 12.992708 0.000036 170.82982 -90.000078 0 0 0 0 0 0
$definebone "Cape_R1" "capedummy" 0.182304 -0.378484 -0.074587 37.51951 -20.981026 57.802791 0 0 0 0 0 0
$definebone "Cape_R2" "Cape_R1" 6.583296 0.000038 0 0.000001 29.620485 -0.000003 0 0 0 0 0 0
$definebone "Cape_R3" "Cape_R2" 7.863506 0 0 0.000002 8.621008 -0.000003 0 0 0 0 0 0

$jigglebone "Cape_M1"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -15 2
		left_friction 0
		up_constraint -3 0
		up_friction 0
		forward_constraint -5 5
		forward_friction 0
	}
}
$jigglebone "Cape_M2"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -15 2
		left_friction 0
		up_constraint -12 0
		up_friction 0
		forward_constraint -12 12
		forward_friction 0
	}
}
$jigglebone "Cape_M3"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -15 2
		left_friction 0
		up_constraint -12 0
		up_friction 0
		forward_constraint -12 12
		forward_friction 0
	}
}
$jigglebone "Cape_L1"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -2 15
		left_friction 0
		up_constraint 0 3
		up_friction 0
		forward_constraint -5 0
		forward_friction 0
	}
}
$jigglebone "Cape_L2"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -2 15
		left_friction 0
		up_constraint 0 12
		up_friction 0
		forward_constraint -12 12
		forward_friction 0
	}
}
$jigglebone "Cape_L3"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -2 15
		left_friction 0
		up_constraint 0 12
		up_friction 0
		forward_constraint -12 12
		forward_friction 0
	}
}
$jigglebone "Cape_R1"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -15 2
		left_friction 0
		up_constraint -3 0
		up_friction 0
		forward_constraint 0 5
		forward_friction 0
	}
}
$jigglebone "Cape_R2"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -15 2
		left_friction 0
		up_constraint -12 0
		up_friction 0
		forward_constraint -12 12
		forward_friction 0
	}
}
$jigglebone "Cape_R3"
{
	has_base_spring
	{
		base_mass 0
		stiffness 350
		damping 40
		left_constraint -15 2
		left_friction 0
		up_constraint -12 0
		up_friction 0
		forward_constraint -12 12
		forward_friction 0
	}
}

$sectionframes 30 150

$poseparameter "aim_yaw" -70 70 loop 0
$poseparameter "move_yaw" -180 180 loop 0
$poseparameter "head_yaw" -70 70 loop 0
$poseparameter "head_pitch" -40 40 loop 0
$poseparameter "snout" 0 10 loop 0

$animation "b_scared_corrective_animation" "pigmask_anims\b_scared_corrective_animation.smd" {
}

$animation "b_flashlight_corrective_animation" "pigmask_anims\b_flashlight_corrective_animation.smd" {
}

$animation "a_null_corrective_animation" "pigmask_anims\a_null_corrective_animation.smd" {
}

$animation "b_snout_corrective_animation" "pigmask_anims\b_snout_corrective_animation.smd" {
}

$animation "aim_right_corrective_animation" "pigmask_anims\aim_right_corrective_animation.smd" {
}

$animation "aim_left_corrective_animation" "pigmask_anims\aim_left_corrective_animation.smd" {
}

$animation "aim_up_corrective_animation" "pigmask_anims\aim_up_corrective_animation.smd" {
}

$animation "aim_down_corrective_animation" "pigmask_anims\aim_down_corrective_animation.smd" {
}

$animation "a_RunAdd_corrective_animation" "pigmask_anims\a_RunAdd_corrective_animation.smd" {
}

$animation "a_WalkAdd_corrective_animation" "pigmask_anims\a_WalkAdd_corrective_animation.smd" {
}

$animation "idle.smd" "pigmask_anims\idle.smd" {
	fps 30
}

$animation "idle2" "pigmask_anims\idle2.smd" {
	fps 15
	loop
}

$animation "a_WalkS" "pigmask_anims\a_WalkS.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_WalkSE" "pigmask_anims\a_WalkSE.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_WalkE" "pigmask_anims\a_WalkE.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_WalkNE" "pigmask_anims\a_WalkNE.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_WalkNW" "pigmask_anims\a_WalkNW.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_WalkW" "pigmask_anims\a_WalkW.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_WalkSW" "pigmask_anims\a_WalkSW.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "a_walkN" "pigmask_anims\a_walkN.smd" {
	fps 70
	loop
	walkframe 40 LX LY
}

$animation "swimS" "pigmask_anims\swimS.smd" {
	fps 70
	loop
}

$animation "SwimE" "pigmask_anims\SwimE.smd" {
	fps 70
	loop
}

$animation "SwimN" "pigmask_anims\SwimN.smd" {
	fps 70
	loop
}

$animation "Swimw" "pigmask_anims\Swimw.smd" {
	fps 70
	loop
}

$animation "a_runS" "pigmask_anims\a_runS.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runSE" "pigmask_anims\a_runSE.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runE" "pigmask_anims\a_runE.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runNE" "pigmask_anims\a_runNE.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runNW" "pigmask_anims\a_runNW.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runW" "pigmask_anims\a_runW.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runSW" "pigmask_anims\a_runSW.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_runN" "pigmask_anims\a_runN.smd" {
	fps 100
	loop
	walkframe 39 LX LY
}

$animation "a_crawl" "pigmask_anims\a_crawl.smd" {
	fps 35
	loop
}

$animation "a_crawlS" "pigmask_anims\a_crawlS.smd" {
	fps 35
	loop
}

$animation "a_crawlSW" "pigmask_anims\a_crawlSW.smd" {
	fps 35
	loop
}

$animation "a_crawlNW" "pigmask_anims\a_crawlNW.smd" {
	fps 35
	loop
}

$animation "a_crawlNE" "pigmask_anims\a_crawlNE.smd" {
	fps 35
	loop
}

$animation "a_crawlSE" "pigmask_anims\a_crawlSE.smd" {
	fps 35
	loop
}

$animation "a_crawlE" "pigmask_anims\a_crawlE.smd" {
	fps 35
	loop
}

$animation "a_crawlW" "pigmask_anims\a_crawlW.smd" {
	fps 35
	loop
}

$animation "a_RunAdd" "pigmask_anims\a_RunAdd.smd" {
	fps 100
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "a_RunAdd_corrective_animation" 0
	walkframe 39 LX LY
}

$animation "a_WalkAdd" "pigmask_anims\a_WalkAdd.smd" {
	fps 70
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "a_WalkAdd_corrective_animation" 0
	walkframe 40 LX LY
}

$animation "a_null" "pigmask_anims\a_null.smd" {
	fps 60
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "a_null_corrective_animation" 0
}

$animation "b_scared" "pigmask_anims\b_scared.smd" {
	fps 15
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "b_scared_corrective_animation" 0
}

$animation "a_snout" "pigmask_anims\a_snout.smd" {
	fps 30
}

$animation "b_snout" "pigmask_anims\b_snout.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "b_snout_corrective_animation" 0
}

$animation "a_flashlight" "pigmask_anims\a_flashlight.smd" {
	fps 60
}

$animation "b_flashlight" "pigmask_anims\b_flashlight.smd" {
	fps 60
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "b_flashlight_corrective_animation" 0
}

$animation "aim_right" "pigmask_anims\aim_right.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_right_corrective_animation" 0
}

$animation "aim_left" "pigmask_anims\aim_left.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_left_corrective_animation" 0
}

$animation "aim_up" "pigmask_anims\aim_up.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_up_corrective_animation" 0
}

$animation "aim_down" "pigmask_anims\aim_down.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_down_corrective_animation" 0
}

$sequence "scared" {
	"b_scared"
	activity "ACT_HL2MP_WALK_AGITATED" 1
	delta
	fadein 0.2
	fadeout 0.2
	realtime
}

$sequence "flashlight" {
	"b_flashlight"
	activity "ACT_GESTURE_MELEE_ATTACK1" -1
	delta
	fadein 0.2
	fadeout 0.2
	snap
}

$sequence "snout" {
	"a_null"
	"b_snout"
	activity "ACT_IDONTCARE" 1
	autoplay
	blend "snout" 0 10
	blendwidth 2
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "auto_leftright" {
	"aim_right"
	"aim_left"
	autoplay
	blend "aim_yaw" -70 70
	blendwidth 2
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "auto_leftright2" {
	"aim_right"
	"aim_left"
	autoplay
	blend "head_yaw" -70 70
	blendwidth 2
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "auto_updown" {
	"aim_up"
	"aim_down"
	autoplay
	blend "head_pitch" -40 40
	blendwidth 2
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "Runadd" {
	"a_RunAdd"
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "Walkadd" {
	"a_WalkAdd"
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "walk" {
	"a_WalkS"
	"a_WalkSE"
	"a_WalkE"
	"a_WalkNE"
	"a_walkN"
	"a_WalkNW"
	"a_WalkW"
	"a_WalkSW"
	"a_WalkS"
	activity "ACT_HL2MP_WALK" -1
	blend "move_yaw" -180 180
	blendwidth 9
	fadein 0.2
	fadeout 0.2
	addlayer "Walkadd"
}

$sequence "walk_scared" {
	"a_WalkS"
	"a_WalkSE"
	"a_WalkE"
	"a_WalkNE"
	"a_walkN"
	"a_WalkNW"
	"a_WalkW"
	"a_WalkSW"
	"a_WalkS"
	activity "ACT_HL2MP_WALK" -1
	blend "move_yaw" -180 180
	blendwidth 9
	fadein 0.2
	fadeout 0.2
	addlayer "Walkadd"
	addlayer "scared"
}

$sequence "swim" {
	"swimS"
	"SwimE"
	"SwimN"
	"Swimw"
	"swimS"
	activity "ACT_HL2MP_SWIM" -1
	blend "move_yaw" -180 180
	blendwidth 5
	fadein 0.2
	fadeout 0.2
}

$sequence "run" {
	"a_runS"
	"a_runSE"
	"a_runE"
	"a_runNE"
	"a_runN"
	"a_runNW"
	"a_runW"
	"a_runSW"
	"a_runS"
	activity "ACT_HL2MP_RUN" -1
	blend "move_yaw" -180 180
	blendwidth 9
	fadein 0.2
	fadeout 0.2
	addlayer "Runadd"
}

$sequence "run_scared" {
	"a_runS"
	"a_runSE"
	"a_runE"
	"a_runNE"
	"a_runN"
	"a_runNW"
	"a_runW"
	"a_runSW"
	"a_runS"
	activity "ACT_HL2MP_RUN2" -1
	blend "move_yaw" -180 180
	blendwidth 9
	fadein 0.2
	fadeout 0.2
	addlayer "Runadd"
	addlayer "scared"
}

$sequence "crawl" {
	"a_crawlS"
	"a_crawlSE"
	"a_crawlE"
	"a_crawlNE"
	"a_crawl"
	"a_crawlNW"
	"a_crawlW"
	"a_crawlSW"
	"a_crawlS"
	activity "ACT_HL2MP_WALK_CROUCH" -1
	blend "move_yaw" -180 180
	blendwidth 9
	fadein 0.2
	fadeout 0.2
	node "0"
}

$sequence "ragdoll" {
	"pigmask_anims\ragdoll.smd"
	activity "ACT_DIERAGDOLL" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 15
	loop
}

$sequence "idle" {
	"idle2"
	activity "ACT_HL2MP_IDLE" -1
	fadein 0.2
	fadeout 0.2
	node "0"
}

$sequence "idle_scared" {
	"pigmask_anims\idle_scared.smd"
	activity "ACT_HL2MP_IDLE" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 25
	loop
}

$sequence "swimidle" {
	"pigmask_anims\swimidle.smd"
	activity "ACT_HL2MP_SWIM_IDLE" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 15
	loop
}

$sequence "taunt" {
	"pigmask_anims\taunt.smd"
	activity "ACT_HL2MP_TAUNT" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 55
	loop
}

$sequence "taunt2" {
	"pigmask_anims\taunt2.smd"
	activity "ACT_HL2MP_TAUNT2" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 40
	loop
}

$sequence "crouchidle" {
	"pigmask_anims\crouchidle.smd"
	activity "ACT_HL2MP_IDLE_CROUCH" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 22
	loop
}

$sequence "jump" {
	"pigmask_anims\jump.smd"
	activity "ACT_HL2MP_JUMP" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 40
}

$sequence "jump2" {
	"pigmask_anims\jump2.smd"
	activity "ACT_MP_JUMP" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 40
	loop
}

$collisionjoints "pigmask_physics.smd"
{
	$mass 45
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone "body1"


	$jointconstrain "Lleg1" x limit -25 25 0
	$jointconstrain "Lleg1" y limit -70 60 0
	$jointconstrain "Lleg1" z limit -50 30 0

	$jointconstrain "Lleg2" x limit 0 0 0
	$jointconstrain "Lleg2" y limit 0 0 0
	$jointconstrain "Lleg2" z limit -90 0 0

	$jointconstrain "Rleg1" x limit -25 25 0
	$jointconstrain "Rleg1" y limit -70 60 0
	$jointconstrain "Rleg1" z limit 0 0 0

	$jointconstrain "Rleg2" x limit 0 0 0
	$jointconstrain "Rleg2" y limit 0 0 0
	$jointconstrain "Rleg2" z limit -90 0 0

	$jointconstrain "Rfoot" x limit -25 25 0
	$jointconstrain "Rfoot" y limit -35 35 0
	$jointconstrain "Rfoot" z limit -45 15 0

	$jointconstrain "Body2" x limit -15 15 0
	$jointconstrain "Body2" y limit -15 15 0
	$jointconstrain "Body2" z limit -15 15 0

	$jointconstrain "Larm_01" x limit 0 0 0
	$jointconstrain "Larm_01" y limit -100 50 0
	$jointconstrain "Larm_01" z limit -90 130 0

	$jointconstrain "Larm_02" x limit 0 0 0
	$jointconstrain "Larm_02" y limit -90 0 0
	$jointconstrain "Larm_02" z limit 0 0 0

	$jointconstrain "Rarm_1" x limit 0 0 0
	$jointconstrain "Rarm_1" y limit -100 50 0
	$jointconstrain "Rarm_1" z limit -90 130 0

	$jointconstrain "Rarm_2" x limit 0 0 0
	$jointconstrain "Rarm_2" y limit -90 0 0
	$jointconstrain "Rarm_2" z limit 0 0 0

	$jointconstrain "ValveBiped.Bip01_R_Hand" x limit -40 50 0
	$jointconstrain "ValveBiped.Bip01_R_Hand" y limit -30 30 0
	$jointconstrain "ValveBiped.Bip01_R_Hand" z limit -60 50 0

	$jointconstrain "Head" x limit -55 55 0
	$jointconstrain "Head" y limit -15 15 0
	$jointconstrain "Head" z limit -25 50 0

	$jointconstrain "ValveBiped.Bip01_L_Hand" x limit -40 50 0
	$jointconstrain "ValveBiped.Bip01_L_Hand" y limit -30 30 0
	$jointconstrain "ValveBiped.Bip01_L_Hand" z limit -60 50 0

	$jointconstrain "Lfoot" x limit -25 25 0
	$jointconstrain "Lfoot" y limit -35 35 0
	$jointconstrain "Lfoot" z limit -45 15 0
}
