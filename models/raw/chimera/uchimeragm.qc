// Created by Crowbar 0.71

$modelname "uch\uchimeragm.mdl"

$bodygroup "studio"
{
	blank
	studio "Uchimera.smd"
}
$bodygroup "Bird"
{
	blank
	studio "Bird.smd"
}
$bodygroup "studio"
{
	studio "Uchimera_2.smd"
}


$surfaceprop "flesh"

$contents "solid"

$illumposition 0 -20 0 "StgNewporkUltimateChimera_RotN"

$opaque

$cdmaterials "models\uch\Uchimera\"

$texturegroup "skinfamilies"
{
	{ "StgNewporkUltimateChimera_Body"  }
	{ "StgNewporkUltimateChimera_Body2" }
}

$attachment "L_eye" "StgNewporkUltimateChimera_JMouthN" 16 -15 14 rotate 0 0 0
$attachment "R_eye" "StgNewporkUltimateChimera_JMouthN" -16 -15 14 rotate 0 0 0
$attachment "Button" "StgNewporkUltimateChimera_HeadN" 0 -10 25 rotate 0 0 0
$attachment "Bird" "StgNewporkUltimateChimera_ToriN" 0 0 0 rotate 0 0 0

$cbox 0 0 0 0 0 0

$bbox -55.266 -52.141 -4.348 80.111 51.704 112.236

$definebone "StgNewporkUltimateChimera_TransN" "" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RotN" "StgNewporkUltimateChimera_TransN" 0 0 32 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_HipN" "StgNewporkUltimateChimera_RotN" 0 0 0 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LLegJ" "StgNewporkUltimateChimera_HipN" 16.613764 7.868512 -6.635649 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LKneeJ" "StgNewporkUltimateChimera_LLegJ" 0 1.429645 -9.787584 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LFootJ" "StgNewporkUltimateChimera_LKneeJ" 0 5.828545 -5.828545 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LToeN" "StgNewporkUltimateChimera_LFootJ" 0 -1.759564 -6.268448 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RLegJ" "StgNewporkUltimateChimera_HipN" -16.61376 7.868512 -6.635649 0 0 -179.999978 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RKneeJ" "StgNewporkUltimateChimera_RLegJ" 0 -1.429632 9.787585 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RFootJ" "StgNewporkUltimateChimera_RKneeJ" 0 -5.828576 5.828545 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RToeN" "StgNewporkUltimateChimera_RFootJ" 0 1.759583 6.268448 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_TailNa" "StgNewporkUltimateChimera_HipN" 0 15.585983 6.323841 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_TailNb" "StgNewporkUltimateChimera_TailNa" 0 8.216768 0 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_TailNc" "StgNewporkUltimateChimera_TailNb" 0 18.898527 0 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_TailNd" "StgNewporkUltimateChimera_TailNc" 0 16.638947 0 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_TailNe" "StgNewporkUltimateChimera_TailNd" 0 18.066498 0 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_WaistN" "StgNewporkUltimateChimera_HipN" 0 -6.317984 0.182659 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_AgoN" "StgNewporkUltimateChimera_WaistN" 0 -25.800066 -6.76096 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_HeadN" "StgNewporkUltimateChimera_WaistN" 0 1.319674 2.969265 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LWingNa" "StgNewporkUltimateChimera_HeadN" 13.668675 -10.68541 12.400223 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LWingNb" "StgNewporkUltimateChimera_LWingNa" 10.240001 -5.120001 19.199997 -30.000014 0 60.000029 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RWingNa" "StgNewporkUltimateChimera_HeadN" -13.668673 -10.68541 12.400063 0 0 -179.999978 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RWingNb" "StgNewporkUltimateChimera_RWingNa" -10.24 5.120001 -19.200001 -30.000014 0 60.000029 0 0 0 0 0 0
$definebone "button" "StgNewporkUltimateChimera_HeadN" -0.00001 -11.39209 18.128075 -74.568167 89.999927 -89.999982 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_JMouthN" "StgNewporkUltimateChimera_HeadN" 0 -36.039043 5.709538 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_ToriN" "StgNewporkUltimateChimera_JMouthN" 0 -9.965504 34.60928 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LShoulderJ" "StgNewporkUltimateChimera_WaistN" 18.0888 -9.127745 -11.987041 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LArmJ" "StgNewporkUltimateChimera_LShoulderJ" 0 -0.549862 -9.457664 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LHandN" "StgNewporkUltimateChimera_LArmJ" 0 -3.811647 -7.346176 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RShoulderJ" "StgNewporkUltimateChimera_WaistN" -18.0888 -9.127745 -11.987007 0 0 179.999978 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RArmJ" "StgNewporkUltimateChimera_RShoulderJ" 0 0.549856 9.457663 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RHandN" "StgNewporkUltimateChimera_RArmJ" 0 3.811648 7.346176 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LToriwingN" "StgNewporkUltimateChimera_ToriN" 4.59248 -0.679829 1.140045 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_LTorilegN" "StgNewporkUltimateChimera_ToriN" 2.169312 0.069103 -3.644417 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RTorilegN" "StgNewporkUltimateChimera_ToriN" -2.169312 0.069134 -3.644447 0 0 -179.999978 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_RToriwingN" "StgNewporkUltimateChimera_ToriN" -4.59248 -0.679989 1.140205 0 0 -179.999978 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_ToriheadN" "StgNewporkUltimateChimera_ToriN" 0 -2.227551 5.197601 0 0 0 0 0 0 0 0 0
$definebone "StgNewporkUltimateChimera_TopN" "" -0.953616 0 -1.311814 0 0 0.190451 0 0 0 0 0 0


$sectionframes 30 150

$poseparameter "move_yaw" -180 180 loop 0
$poseparameter "aim_yaw" 0 0 loop 0

$animation "b_tailslap_corrective_animation" "uchimeragm_anims\b_tailslap_corrective_animation.smd" {
}

$animation "a_WalkN" "uchimeragm_anims\a_WalkN.smd" {
	fps 45
	loop
	walkframe 40 LX
}

$animation "a_WalkE" "uchimeragm_anims\a_WalkE.smd" {
	fps 45
	loop
	walkframe 40 LX LY
}

$animation "a_WalkW" "uchimeragm_anims\a_WalkW.smd" {
	fps 45
	loop
	walkframe 40 LX LY
}

$animation "a_WalkS" "uchimeragm_anims\a_WalkS.smd" {
	fps 45
	loop
	walkframe 40 LX
}

$animation "a_idle" "uchimeragm_anims\a_idle.smd" {
	fps 45
	loop
	walkframe 100 LX
}

$animation "a_tailslap" "uchimeragm_anims\a_tailslap.smd" {
	fps 45
}

$animation "b_tailslap" "uchimeragm_anims\b_tailslap.smd" {
	fps 45
	// Crowbar writes this subtract option to prevent jigglebone and poseparameter problems when delta sequences are recompiled.
	subtract "b_tailslap_corrective_animation" 0
}

$sequence "walk" {
	"a_WalkS"
	"a_WalkE"
	"a_WalkN"
	"a_WalkW"
	"a_WalkS"
	activity "ACT_HL2MP_WALK" -1
	blend "move_yaw" -180 180
	blendwidth 5
	{ event AE_CL_PLAYSOUND 19 "stip.stomp" }
	{ event AE_CL_PLAYSOUND 38 "stip.stomp" }
	fadein 0.2
	fadeout 0.2
}

$sequence "aim" {
	"a_idle"
	"a_idle"
	"a_idle"
	"a_idle"
	"a_idle"
	activity "ACT_AIM" -1
	blend "aim_yaw" 0 0
	blendwidth 5
	fadein 0.2
	fadeout 0.2
}

$sequence "run" {
	"uchimeragm_anims\run.smd"
	activity "ACT_HL2MP_RUN" -1
	{ event AE_CL_PLAYSOUND 6 "stip.stomp" }
	{ event AE_CL_PLAYSOUND 31 "stip.stomp" }
	fadein 0.2
	fadeout 0.2
	fps 90
	loop
	walkframe 40 LX LY
}

$sequence "ragdoll" {
	"uchimeragm_anims\ragdoll.smd"
	activity "ACT_DIERAGDOLL" -1
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 30
	loop
}

$sequence "idle" {
	"uchimeragm_anims\idle.smd"
	activity "ACT_HL2MP_IDLE" 50
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 15
	loop
}

$sequence "jump" {
	"uchimeragm_anims\jump.smd"
	activity "ACT_JUMP" 50
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 45
	loop
}

$sequence "jump2" {
	"uchimeragm_anims\jump2.smd"
	activity "ACT_HL2MP_JUMP" 50
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 45
	loop
}

$sequence "jump3" {
	"uchimeragm_anims\jump3.smd"
	activity "ACT_HL2MP_JUMP2" 50
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 45
	loop
}

$sequence "idle2" {
	"uchimeragm_anims\idle2.smd"
	activity "ACT_IDLE" 1
	{ event AE_CL_PLAYSOUND 0 "gril.growl" }
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 17
	loop
}

$sequence "idle3" {
	"uchimeragm_anims\idle3.smd"
	activity "ACT_IDLE2" 3
	{ event AE_CL_PLAYSOUND 0 "riar.roar" }
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 12
	loop
}

$sequence "bite" {
	"uchimeragm_anims\bite.smd"
	activity "ACT_MELEE_ATTACK1" -1
	{ event AE_CL_PLAYSOUND 0 "bit.bite" }
	fadein 0.2
	fadeout 0.2
	node "0"
	fps 60
	loop
}

$sequence "tailslap" {
	"b_tailslap"
	activity "ACT_GESTURE_MELEE_ATTACK1" -1
	delta
	fadein 0.2
	fadeout 0.2
}

$collisionjoints "uchimeragm_physics.smd"
{
	$mass 120
	$inertia 1
	$damping 0
	$rotdamping 0
	$rootbone "root"


	$jointconstrain "StgNewporkUltimateChimera_RShoulderJ" x limit -60 50 0
	$jointconstrain "StgNewporkUltimateChimera_RShoulderJ" y limit -40 40 0
	$jointconstrain "StgNewporkUltimateChimera_RShoulderJ" z limit -25 50 0

	$jointconstrain "StgNewporkUltimateChimera_LShoulderJ" x limit -60 50 0
	$jointconstrain "StgNewporkUltimateChimera_LShoulderJ" y limit -40 40 0
	$jointconstrain "StgNewporkUltimateChimera_LShoulderJ" z limit -25 50 0

	$jointconstrain "StgNewporkUltimateChimera_LArmJ" x limit -60 30 0
	$jointconstrain "StgNewporkUltimateChimera_LArmJ" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_LArmJ" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_HeadN" x limit -70 0 0
	$jointconstrain "StgNewporkUltimateChimera_HeadN" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_HeadN" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_RWingNa" x limit -50 40 0
	$jointconstrain "StgNewporkUltimateChimera_RWingNa" y limit -45 60 0
	$jointconstrain "StgNewporkUltimateChimera_RWingNa" z limit -40 40 0

	$jointconstrain "StgNewporkUltimateChimera_LWingNa" x limit -50 40 0
	$jointconstrain "StgNewporkUltimateChimera_LWingNa" y limit -45 60 0
	$jointconstrain "StgNewporkUltimateChimera_LWingNa" z limit -40 40 0

	$jointconstrain "StgNewporkUltimateChimera_LWingNb" x limit -50 20 0
	$jointconstrain "StgNewporkUltimateChimera_LWingNb" y limit -45 20 0
	$jointconstrain "StgNewporkUltimateChimera_LWingNb" z limit -30 30 0

	$jointconstrain "StgNewporkUltimateChimera_RArmJ" x limit -60 30 0
	$jointconstrain "StgNewporkUltimateChimera_RArmJ" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_RArmJ" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_TailNb" x limit -50 50 0
	$jointconstrain "StgNewporkUltimateChimera_TailNb" y limit -30 30 0
	$jointconstrain "StgNewporkUltimateChimera_TailNb" z limit -50 50 0

	$jointconstrain "StgNewporkUltimateChimera_TailNc" x limit -45 45 0
	$jointconstrain "StgNewporkUltimateChimera_TailNc" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_TailNc" z limit -45 45 0

	$jointconstrain "StgNewporkUltimateChimera_TailNd" x limit -50 50 0
	$jointconstrain "StgNewporkUltimateChimera_TailNd" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_TailNd" z limit -50 50 0

	$jointconstrain "StgNewporkUltimateChimera_RLegJ" x limit -70 30 0
	$jointconstrain "StgNewporkUltimateChimera_RLegJ" y limit -50 20 0
	$jointconstrain "StgNewporkUltimateChimera_RLegJ" z limit -30 30 0

	$jointconstrain "StgNewporkUltimateChimera_RKneeJ" x limit -15 50 0
	$jointconstrain "StgNewporkUltimateChimera_RKneeJ" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_RKneeJ" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_RFootJ" x limit -35 35 0
	$jointconstrain "StgNewporkUltimateChimera_RFootJ" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_RFootJ" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_LLegJ" x limit -70 30 0
	$jointconstrain "StgNewporkUltimateChimera_LLegJ" y limit -50 20 0
	$jointconstrain "StgNewporkUltimateChimera_LLegJ" z limit -30 30 0

	$jointconstrain "StgNewporkUltimateChimera_LKneeJ" x limit -15 50 0
	$jointconstrain "StgNewporkUltimateChimera_LKneeJ" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_LKneeJ" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_LFootJ" x limit -35 35 0
	$jointconstrain "StgNewporkUltimateChimera_LFootJ" y limit 0 0 0
	$jointconstrain "StgNewporkUltimateChimera_LFootJ" z limit 0 0 0

	$jointconstrain "StgNewporkUltimateChimera_RWingNb" x limit -50 20 0
	$jointconstrain "StgNewporkUltimateChimera_RWingNb" y limit -45 20 0
	$jointconstrain "StgNewporkUltimateChimera_RWingNb" z limit -30 30 0
}

$collisiontext
{
	break 
	{
		"model"		"nintendo\mother\uchimeragib"
		"health"		"0"
		"fadetime"		"200"
	}
	break 
	{
		"model"		"Fluxmage\mother\birdgib"
		"health"		"0"
		"fadetime"		"200"
	}
}
