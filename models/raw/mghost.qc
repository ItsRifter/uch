// Created by Crowbar 0.71

$modelname "uch\mghost.mdl"

$bodygroup "studio"
{
	blank
	studio "Ghost.smd"
}
$bodygroup "WineGlass"
{
	blank
	studio "WineGlass.smd"
}
$bodygroup "studio"
{
	studio "Ghost_2.smd"
}


$surfaceprop "flesh"

$contents "solid"

$illumposition 10 0 0 "body"

$opaque

$cdmaterials "models\uch\mghost\"

$attachment "forward" "head" 1.75 -5.25 0 rotate 0 -90 -90

$cbox 0 0 0 0 0 0

$bbox -21.2 -32.472 3.632 13.675 27.162 68.043

$definebone "body" "" 0 3.450421 29.339865 -81.069441 -90.000016 90.000016 0 0 0 0 0 0
$definebone "tail" "body" -0.127001 -0.014997 0 0 175.223613 0 0 0 0 0 0 0
$definebone "Bone04" "tail" 16.516695 -9.086778 -5.172995 0 179.413319 0 0 0 0 0 0 0
$definebone "Bone02" "tail" 16.693047 8.137066 -5.173 0 179.413319 0 0 0 0 0 0 0
$definebone "Bone06" "tail" 16.603926 -0.566515 -11.512897 0 179.413319 0 0 0 0 0 0 0
$definebone "Bone01" "tail" 16.69305 8.137072 5.173169 0 179.413319 0 0 0 0 0 0 0
$definebone "Bone03" "tail" 16.516693 -9.086774 5.173175 0 179.413319 0 0 0 0 0 0 0
$definebone "Bone05" "tail" 16.603924 -0.566504 11.512903 0 179.413319 0 0 0 0 0 0 0
$definebone "head" "body" 12.690332 -0.008076 0 0 3.930605 0 0 0 0 0 0 0
$definebone "mouthC" "head" 4.818405 3.989029 -0.000005 0 -84.295114 0 0 0 0 0 0 0
$definebone "mouthU" "head" 4.818405 3.989029 -0.000005 0 -79.295068 0 0 0 0 0 0 0
$definebone "mouthB" "head" 4.818405 3.989029 -0.000005 0 -99.295084 0 0 0 0 0 0 0
$definebone "Reye" "head" 13.195881 4.53833 5.783485 0 -85.00001 0 0 0 0 0 0 0
$definebone "Leye" "head" 13.195881 4.538328 -5.783401 0 -85.00001 0 0 0 0 0 0 0
$definebone "Rarm1" "body" 8.261538 -0.254608 13.312732 -89.999982 98.930557 0 0 0 0 0 0 0
$definebone "Rarm2" "Rarm1" 2.519894 1.13345 -0.154946 0 0 90.000037 0 0 0 0 0 0
$definebone "Larm1" "body" 8.261538 -0.254605 -13.312605 -89.999982 -81.069346 0 0 0 0 0 0 0
$definebone "Larm2" "Larm1" -2.519996 -1.133453 0.154949 0.000057 0 90.000037 0 0 0 0 0 0
$definebone "glass" "Rarm2" 10.498699 -0.24702 -0.231327 -89.999982 -89.999982 0 0 0 0 0 0 0
$definebone "WineL" "glass" 9.880554 0.010393 -0.017773 0 0 -89.999982 0 0 0 0 0 0
$definebone "wine" "WineL" 0.038452 0.000001 -0.000006 0 0 89.999982 0 0 0 0 0 0

$jigglebone "WineL"
{
	is_flexible
	{
		length 5
		tip_mass 5
		pitch_stiffness 1000
		pitch_damping 10
		yaw_stiffness 100
		yaw_damping 0
		along_stiffness 100
		along_damping 0
		angle_constraint 30.000001
	}
}
$jigglebone "wine"
{
	is_flexible
	{
		length 5
		tip_mass 5
		pitch_stiffness 1000
		pitch_damping 20
		yaw_stiffness 100
		yaw_damping 0
		along_stiffness 100
		along_damping 0
		angle_constraint 30.000001
	}
}

$sectionframes 30 120

$poseparameter "move_yaw" -180 180 loop 0
$poseparameter "head_yaw" -30 30 loop 0
$poseparameter "head_pitch" -20 10 loop 0

$animation "aa_hover_corrective_animation" "mghost_anims\aa_hover_corrective_animation.smd" {
}

$animation "aa_bob_corrective_animation" "mghost_anims\aa_bob_corrective_animation.smd" {
}

$animation "aim_right_corrective_animation" "mghost_anims\aim_right_corrective_animation.smd" {
}

$animation "aim_left_corrective_animation" "mghost_anims\aim_left_corrective_animation.smd" {
}

$animation "aim_up_corrective_animation" "mghost_anims\aim_up_corrective_animation.smd" {
}

$animation "aim_down_corrective_animation" "mghost_anims\aim_down_corrective_animation.smd" {
}

$animation "a_holdcup_corrective_animation" "mghost_anims\a_holdcup_corrective_animation.smd" {
}

$animation "b_null_corrective_animation" "mghost_anims\b_null_corrective_animation.smd" {
}

$animation "aa_talk2_corrective_animation" "mghost_anims\aa_talk2_corrective_animation.smd" {
}

$animation "aa_talk1_corrective_animation" "mghost_anims\aa_talk1_corrective_animation.smd" {
}

$animation "a_eyes_corrective_animation" "mghost_anims\a_eyes_corrective_animation.smd" {
}

$animation "b_drink_corrective_animation" "mghost_anims\b_drink_corrective_animation.smd" {
}

$animation "a_null" "mghost_anims\a_null.smd" {
	fps 30
	loop
}

$animation "b_null" "mghost_anims\b_null.smd" {
	fps 30
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "b_null_corrective_animation" 0
}

$animation "a_null2" "mghost_anims\a_null2.smd" {
	fps 30
	loop
}

$animation "aa_hover" "mghost_anims\aa_hover.smd" {
	fps 45
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aa_hover_corrective_animation" 0
}

$animation "aa_bob" "mghost_anims\aa_bob.smd" {
	fps 10
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aa_bob_corrective_animation" 0
}

$animation "aim_right" "mghost_anims\aim_right.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_right_corrective_animation" 0
}

$animation "aim_left" "mghost_anims\aim_left.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_left_corrective_animation" 0
}

$animation "aim_up" "mghost_anims\aim_up.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_up_corrective_animation" 0
}

$animation "aim_down" "mghost_anims\aim_down.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aim_down_corrective_animation" 0
}

$animation "a_WalkS" "mghost_anims\a_WalkS.smd" {
	fps 45
	loop
}

$animation "a_WalkE" "mghost_anims\a_WalkE.smd" {
	fps 30
	loop
}

$animation "a_WalkW" "mghost_anims\a_WalkW.smd" {
	fps 30
	loop
}

$animation "a_walkN" "mghost_anims\a_walkN.smd" {
	fps 30
	loop
}

$animation "a_holdcup" "mghost_anims\a_holdcup.smd" {
	fps 10
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "a_holdcup_corrective_animation" 0
}

$animation "aa_talk1" "mghost_anims\aa_talk1.smd" {
	fps 40
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aa_talk1_corrective_animation" 0
}

$animation "aa_talk2" "mghost_anims\aa_talk2.smd" {
	fps 50
	loop
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "aa_talk2_corrective_animation" 0
}

$animation "a_eyes" "mghost_anims\a_eyes.smd" {
	fps 30
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "a_eyes_corrective_animation" 0
}

$animation "a_drink" "mghost_anims\a_drink.smd" {
	fps 45
}

$animation "b_drink" "mghost_anims\b_drink.smd" {
	fps 45
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "b_drink_corrective_animation" 0
}

$sequence "hover" {
	"aa_hover"
	autoplay
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "bob" {
	"aa_bob"
	autoplay
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "auto_leftright" {
	"aim_right"
	"aim_left"
	autoplay
	blend "head_yaw" -30 30
	blendwidth 2
	delta
	fadein 0.2
	fadeout 0.2
}

$sequence "auto_updown" {
	"aim_up"
	"aim_down"
	autoplay
	blend "head_pitch" -20 10
	blendwidth 2
	delta
	fadein 0.2
	fadeout 0.2
}

$sequence "walk" {
	"a_WalkS"
	"a_WalkE"
	"a_walkN"
	"a_WalkW"
	"a_WalkS"
	activity "ACT_HL2MP_WALK" -1
	blend "move_yaw" -180 180
	blendwidth 5
	fadein 0.2
	fadeout 0.2
}

$sequence "holdcup" {
	"a_holdcup"
	delta
	fadein 0.2
	fadeout 0.2
	hidden
}

$sequence "walk2" {
	"a_WalkS"
	"a_WalkE"
	"a_walkN"
	"a_WalkW"
	"a_WalkS"
	activity "ACT_HL2MP_WALK2" -1
	blend "move_yaw" -180 180
	blendwidth 5
	fadein 0.2
	fadeout 0.2
	addlayer "holdcup"
}

$sequence "null" {
	"b_null"
	activity "ACT_GESTURE_MELEE_ATTACK2" -1
	delta
	fadein 0.2
	fadeout 0.2
}

$sequence "Talk2" {
	"aa_talk2"
	delta
	fadein 0.2
	fadeout 0.2
	hidden
	realtime
}

$sequence "Talk" {
	"aa_talk1"
	activity "ACT_GESTURE_RANGE_ATTACK1" -1
	delta
	fadein 0.2
	fadeout 0.2
	addlayer "Talk2"
	realtime
}

$sequence "Eyes" {
	"a_eyes"
	activity "ACT_GESTURE_RANGE_ATTACK2" -1
	delta
	fadein 0.2
	fadeout 0.2
}

$sequence "Drink" {
	"b_drink"
	activity "ACT_GESTURE_MELEE_ATTACK1" -1
	delta
	fadein 0.2
	fadeout 0.2
}

$sequence "ragdoll" {
	"mghost_anims\ragdoll.smd"
	activity "ACT_DIERAGDOLL" -1
	fadein 0.2
	fadeout 0.2
	fps 30
	loop
}

$sequence "Idle1" {
	"mghost_anims\Idle1.smd"
	activity "ACT_HL2MP_IDLE" -1
	fadein 0.2
	fadeout 0.2
	fps 30
	loop
}

$sequence "Idle2" {
	"mghost_anims\Idle2.smd"
	activity "ACT_HL2MP_IDLE2" -1
	fadein 0.2
	fadeout 0.2
	fps 10
	loop
}

$collisionjoints "mghost_physics.smd"
{
	$mass 45
	$inertia 1.5
	$damping 0
	$rotdamping 0
	$rootbone "Body"


	$jointconstrain "Larm1" x limit -40 40 0
	$jointconstrain "Larm1" y limit -90 60 0
	$jointconstrain "Larm1" z limit -90 140 0

	$jointconstrain "Rarm1" x limit -40 40 0
	$jointconstrain "Rarm1" y limit -90 60 0
	$jointconstrain "Rarm1" z limit -90 140 0

	$jointconstrain "Rarm2" x limit 0 0 0
	$jointconstrain "Rarm2" y limit 0 0 0
	$jointconstrain "Rarm2" z limit 0 90 0

	$jointconstrain "Larm2" x limit 0 0 0
	$jointconstrain "Larm2" y limit 0 0 0
	$jointconstrain "Larm2" z limit 0 90 0

	$jointconstrain "tail" x limit -20 20 0
	$jointconstrain "tail" y limit -45 45 0
	$jointconstrain "tail" z limit -45 50 0
}
