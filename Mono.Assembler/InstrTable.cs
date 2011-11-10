//
// Mono.ILASM.InstrTable
//
// Author(s):
//  Jackson Harper (Jackson@LatitudeGeo.com)
//
// (C) 2003 Jackson Harper, All rights reserved
//

using System.Collections;
using System.Reflection.Emit;

namespace Mono.Assembler
{
	public class InstrTable
	{
		private static Hashtable inst_table;

		static InstrTable()
		{
			CreateInstTable();
		}

		public static ILToken GetToken(string str)
		{
			return inst_table[str] as ILToken;
		}

		public static bool IsInstr(string str)
		{
			return inst_table.Contains(str);
		}

		private static void CreateInstTable()
		{
			inst_table = new Hashtable();

			inst_table["nop"] = new ILToken(Token.INSTR_NONE, OpCodes.Nop);
			inst_table["break"] = new ILToken(Token.INSTR_NONE, OpCodes.Break);
			inst_table["ldarg.0"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldarg_0);
			inst_table["ldarg.1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldarg_1);
			inst_table["ldarg.2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldarg_2);
			inst_table["ldarg.3"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldarg_3);
			inst_table["ldloc.0"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldloc_0);
			inst_table["ldloc.1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldloc_1);
			inst_table["ldloc.2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldloc_2);
			inst_table["ldloc.3"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldloc_3);
			inst_table["stloc.0"] = new ILToken(Token.INSTR_NONE, OpCodes.Stloc_0);
			inst_table["stloc.1"] = new ILToken(Token.INSTR_NONE, OpCodes.Stloc_1);
			inst_table["stloc.2"] = new ILToken(Token.INSTR_NONE, OpCodes.Stloc_2);
			inst_table["stloc.3"] = new ILToken(Token.INSTR_NONE, OpCodes.Stloc_3);
			inst_table["ldnull"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldnull);
			inst_table["ldc.i4.m1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_M1);
			inst_table["ldc.i4.M1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_M1);
			inst_table["ldc.i4.0"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_0);
			inst_table["ldc.i4.1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_1);
			inst_table["ldc.i4.2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_2);
			inst_table["ldc.i4.3"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_3);
			inst_table["ldc.i4.4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_4);
			inst_table["ldc.i4.5"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_5);
			inst_table["ldc.i4.6"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_6);
			inst_table["ldc.i4.7"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_7);
			inst_table["ldc.i4.8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldc_I4_8);
			inst_table["dup"] = new ILToken(Token.INSTR_NONE, OpCodes.Dup);
			inst_table["pop"] = new ILToken(Token.INSTR_NONE, OpCodes.Pop);
			inst_table["ret"] = new ILToken(Token.INSTR_NONE, OpCodes.Ret);
			inst_table["ldind.i1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_I1);
			inst_table["ldind.u1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_U1);
			inst_table["ldind.i2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_I2);
			inst_table["ldind.u2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_U2);
			inst_table["ldind.i4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_I4);
			inst_table["ldind.u4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_U4);
			inst_table["ldind.i8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_I8);
			inst_table["ldind.u8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_I8);
			inst_table["ldind.i"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_I);
			inst_table["ldind.r4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_R4);
			inst_table["ldind.r8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_R8);
			inst_table["ldind.ref"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldind_Ref);
			inst_table["stind.ref"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_Ref);
			inst_table["stind.i1"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_I1);
			inst_table["stind.i2"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_I2);
			inst_table["stind.i4"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_I4);
			inst_table["stind.i8"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_I8);
			inst_table["stind.r4"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_R4);
			inst_table["stind.r8"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_R8);
			inst_table["add"] = new ILToken(Token.INSTR_NONE, OpCodes.Add);
			inst_table["sub"] = new ILToken(Token.INSTR_NONE, OpCodes.Sub);
			inst_table["mul"] = new ILToken(Token.INSTR_NONE, OpCodes.Mul);
			inst_table["div"] = new ILToken(Token.INSTR_NONE, OpCodes.Div);
			inst_table["div.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Div_Un);
			inst_table["rem"] = new ILToken(Token.INSTR_NONE, OpCodes.Rem);
			inst_table["rem.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Rem_Un);
			inst_table["and"] = new ILToken(Token.INSTR_NONE, OpCodes.And);
			inst_table["or"] = new ILToken(Token.INSTR_NONE, OpCodes.Or);
			inst_table["xor"] = new ILToken(Token.INSTR_NONE, OpCodes.Xor);
			inst_table["shl"] = new ILToken(Token.INSTR_NONE, OpCodes.Shl);
			inst_table["shr"] = new ILToken(Token.INSTR_NONE, OpCodes.Shr);
			inst_table["shr.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Shr_Un);
			inst_table["neg"] = new ILToken(Token.INSTR_NONE, OpCodes.Neg);
			inst_table["not"] = new ILToken(Token.INSTR_NONE, OpCodes.Not);
			inst_table["conv.i1"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_I1);
			inst_table["conv.i2"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_I2);
			inst_table["conv.i4"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_I4);
			inst_table["conv.i8"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_I8);
			inst_table["conv.r4"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_R4);
			inst_table["conv.r8"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_R8);
			inst_table["conv.u4"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_U4);
			inst_table["conv.u8"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_U8);
			inst_table["conv.r.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_R_Un);
			inst_table["throw"] = new ILToken(Token.INSTR_NONE, OpCodes.Throw);
			inst_table["conv.ovf.i1.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I1_Un);
			inst_table["conv.ovf.i2.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I2_Un);
			inst_table["conv.ovf.i4.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I4_Un);
			inst_table["conv.ovf.i8.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I8_Un);
			inst_table["conf.ovf.u1.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U1_Un);
			inst_table["conv.ovf.u2.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U2_Un);
			inst_table["conv.ovf.u4.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U4_Un);
			inst_table["conv.ovf.u8.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U8_Un);
			inst_table["conv.ovf.i.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I_Un);
			inst_table["conv.ovf.u.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U_Un);
			inst_table["ldlen"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldlen);
			inst_table["ldelem.i1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_I1);
			inst_table["ldelem.u1"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_U1);
			inst_table["ldelem.i2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_I2);
			inst_table["ldelem.u2"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_U2);
			inst_table["ldelem.i4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_I4);
			inst_table["ldelem.u4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_U4);
			inst_table["ldelem.i8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_I8);
			inst_table["ldelem.u8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_I8);
			inst_table["ldelem.i"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_I);
			inst_table["ldelem.r4"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_R4);
			inst_table["ldelem.r8"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_R8);
			inst_table["ldelem.ref"] = new ILToken(Token.INSTR_NONE, OpCodes.Ldelem_Ref);
			inst_table["Stelem.i"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_I);
			inst_table["Stelem.i1"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_I1);
			inst_table["Stelem.i2"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_I2);
			inst_table["Stelem.i4"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_I4);
			inst_table["Stelem.i8"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_I8);
			inst_table["Stelem.r4"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_R4);
			inst_table["Stelem.r8"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_R8);
			inst_table["Stelem.ref"] = new ILToken(Token.INSTR_NONE, OpCodes.Stelem_Ref);
			inst_table["conv.ovf.i1"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I1);
			inst_table["conv.ovf.u1"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U1);
			inst_table["conv.ovf.i2"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I2);
			inst_table["conv.ovf.u2"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U2);
			inst_table["conv.ovf.i4"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I4);
			inst_table["conv.ovf.u4"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U4);
			inst_table["conv.ovf.i8"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I8);
			inst_table["conv.ovf.u8"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U8);
			inst_table["conv.ovf.u1.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U1_Un);
			inst_table["conv.ovf.u2.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U2_Un);
			inst_table["conv.ovf.u4.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U4_Un);
			inst_table["conv.ovf.u8.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U8_Un);
			inst_table["conv.ovf.i1.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I1_Un);
			inst_table["conv.ovf.i2.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I2_Un);
			inst_table["conv.ovf.i4.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I4_Un);
			inst_table["conv.ovf.i8.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I8_Un);
			inst_table["ckfinite"] = new ILToken(Token.INSTR_NONE, OpCodes.Ckfinite);
			inst_table["conv.u2"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_U2);
			inst_table["conv.u1"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_U1);
			inst_table["conv.i"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_I);
			inst_table["conv.ovf.i"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_I);
			inst_table["conv.ovf.u"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_Ovf_U);
			inst_table["add.ovf"] = new ILToken(Token.INSTR_NONE, OpCodes.Add_Ovf);
			inst_table["add.ovf.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Add_Ovf_Un);
			inst_table["mul.ovf"] = new ILToken(Token.INSTR_NONE, OpCodes.Mul_Ovf);
			inst_table["mul.ovf.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Mul_Ovf_Un);
			inst_table["sub.ovf"] = new ILToken(Token.INSTR_NONE, OpCodes.Sub_Ovf);
			inst_table["sub.ovf.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Sub_Ovf_Un);
			inst_table["endfinally"] = new ILToken(Token.INSTR_NONE, OpCodes.Endfinally);
			// endfault is really just an alias for endfinally
			inst_table["endfault"] = new ILToken(Token.INSTR_NONE, OpCodes.Endfinally);
			inst_table["stind.i"] = new ILToken(Token.INSTR_NONE, OpCodes.Stind_I);
			inst_table["conv.u"] = new ILToken(Token.INSTR_NONE, OpCodes.Conv_U);
			inst_table["arglist"] = new ILToken(Token.INSTR_NONE, OpCodes.Arglist);
			inst_table["ceq"] = new ILToken(Token.INSTR_NONE, OpCodes.Ceq);
			inst_table["cgt"] = new ILToken(Token.INSTR_NONE, OpCodes.Cgt);
			inst_table["cgt.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Cgt_Un);
			inst_table["clt"] = new ILToken(Token.INSTR_NONE, OpCodes.Clt);
			inst_table["clt.un"] = new ILToken(Token.INSTR_NONE, OpCodes.Clt_Un);
			inst_table["localloc"] = new ILToken(Token.INSTR_NONE, OpCodes.Localloc);
			inst_table["endfilter"] = new ILToken(Token.INSTR_NONE, OpCodes.Endfilter);
			inst_table["volatile."] = new ILToken(Token.INSTR_NONE, OpCodes.Volatile);
			inst_table["tail."] = new ILToken(Token.INSTR_NONE, OpCodes.Tailcall);
			inst_table["cpblk"] = new ILToken(Token.INSTR_NONE, OpCodes.Cpblk);
			inst_table["initblk"] = new ILToken(Token.INSTR_NONE, OpCodes.Initblk);
			inst_table["rethrow"] = new ILToken(Token.INSTR_NONE, OpCodes.Rethrow);
			inst_table["refanytype"] = new ILToken(Token.INSTR_NONE, OpCodes.Refanytype);
			inst_table["readonly."] = new ILToken(Token.INSTR_NONE, OpCodes.Readonly);

			//
			// Int operations
			//

			// param
			inst_table["ldarg"] = new ILToken(Token.INSTR_PARAM, OpCodes.Ldarg);
			inst_table["ldarga"] = new ILToken(Token.INSTR_PARAM, OpCodes.Ldarga);
			inst_table["starg"] = new ILToken(Token.INSTR_PARAM, OpCodes.Starg);
			inst_table["ldarg.s"] = new ILToken(Token.INSTR_PARAM, OpCodes.Ldarg_S);
			inst_table["ldarga.s"] = new ILToken(Token.INSTR_PARAM, OpCodes.Ldarga_S);
			inst_table["starg.s"] = new ILToken(Token.INSTR_PARAM, OpCodes.Starg_S);

			// local
			inst_table["ldloc"] = new ILToken(Token.INSTR_LOCAL, OpCodes.Ldloc);
			inst_table["ldloca"] = new ILToken(Token.INSTR_LOCAL, OpCodes.Ldloca);
			inst_table["stloc"] = new ILToken(Token.INSTR_LOCAL, OpCodes.Stloc);
			inst_table["ldloc.s"] = new ILToken(Token.INSTR_LOCAL, OpCodes.Ldloc_S);
			inst_table["ldloca.s"] = new ILToken(Token.INSTR_LOCAL, OpCodes.Ldloca_S);
			inst_table["stloc.s"] = new ILToken(Token.INSTR_LOCAL, OpCodes.Stloc_S);

			inst_table["ldc.i4.s"] = new ILToken(Token.INSTR_I, OpCodes.Ldc_I4_S);
			inst_table["ldc.i4"] = new ILToken(Token.INSTR_I, OpCodes.Ldc_I4);
			inst_table["unaligned."] = new ILToken(Token.INSTR_I, OpCodes.Unaligned);

			//
			// Type operations
			//

			inst_table["cpobj"] = new ILToken(Token.INSTR_TYPE, OpCodes.Cpobj);
			inst_table["ldobj"] = new ILToken(Token.INSTR_TYPE, OpCodes.Ldobj);
			inst_table["castclass"] = new ILToken(Token.INSTR_TYPE, OpCodes.Castclass);
			inst_table["isinst"] = new ILToken(Token.INSTR_TYPE, OpCodes.Isinst);
			inst_table["unbox"] = new ILToken(Token.INSTR_TYPE, OpCodes.Unbox);
			inst_table["unbox.any"] = new ILToken(Token.INSTR_TYPE, OpCodes.Unbox_Any);
			inst_table["stobj"] = new ILToken(Token.INSTR_TYPE, OpCodes.Stobj);
			inst_table["box"] = new ILToken(Token.INSTR_TYPE, OpCodes.Box);
			inst_table["newarr"] = new ILToken(Token.INSTR_TYPE, OpCodes.Newarr);
			inst_table["ldelema"] = new ILToken(Token.INSTR_TYPE, OpCodes.Ldelema);
			inst_table["refanyval"] = new ILToken(Token.INSTR_TYPE, OpCodes.Refanyval);
			inst_table["mkrefany"] = new ILToken(Token.INSTR_TYPE, OpCodes.Mkrefany);
			inst_table["initobj"] = new ILToken(Token.INSTR_TYPE, OpCodes.Initobj);
			inst_table["sizeof"] = new ILToken(Token.INSTR_TYPE, OpCodes.Sizeof);
			inst_table["stelem"] = new ILToken(Token.INSTR_TYPE, OpCodes.Stelem);
			inst_table["ldelem"] = new ILToken(Token.INSTR_TYPE, OpCodes.Ldelem);
			inst_table["stelem.any"] = new ILToken(Token.INSTR_TYPE, OpCodes.Stelem);
			inst_table["ldelem.any"] = new ILToken(Token.INSTR_TYPE, OpCodes.Ldelem);
			inst_table["constrained."] = new ILToken(Token.INSTR_TYPE, OpCodes.Constrained);

			//
			// MethodRef operations
			//

			inst_table["jmp"] = new ILToken(Token.INSTR_METHOD, OpCodes.Jmp);
			inst_table["call"] = new ILToken(Token.INSTR_METHOD, OpCodes.Call);
			inst_table["callvirt"] = new ILToken(Token.INSTR_METHOD, OpCodes.Callvirt);
			inst_table["newobj"] = new ILToken(Token.INSTR_METHOD, OpCodes.Newobj);
			inst_table["ldftn"] = new ILToken(Token.INSTR_METHOD, OpCodes.Ldftn);
			inst_table["ldvirtftn"] = new ILToken(Token.INSTR_METHOD, OpCodes.Ldvirtftn);

			//
			// FieldRef instructions
			//

			inst_table["ldfld"] = new ILToken(Token.INSTR_FIELD, OpCodes.Ldfld);
			inst_table["ldflda"] = new ILToken(Token.INSTR_FIELD, OpCodes.Ldflda);
			inst_table["stfld"] = new ILToken(Token.INSTR_FIELD, OpCodes.Stfld);
			inst_table["ldsfld"] = new ILToken(Token.INSTR_FIELD, OpCodes.Ldsfld);
			inst_table["ldsflda"] = new ILToken(Token.INSTR_FIELD, OpCodes.Ldsflda);
			inst_table["stsfld"] = new ILToken(Token.INSTR_FIELD, OpCodes.Stsfld);

			//
			// Branch Instructions
			//

			inst_table["br"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Br);
			inst_table["brfalse"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Brfalse);
			inst_table["brzero"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Brfalse);
			inst_table["brnull"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Brfalse);
			inst_table["brtrue"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Brtrue);
			inst_table["beq"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Beq);
			inst_table["bge"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bge);
			inst_table["bgt"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bgt);
			inst_table["ble"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Ble);
			inst_table["blt"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Blt);
			inst_table["bne.un"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bne_Un);
			inst_table["bge.un"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bge_Un);
			inst_table["bgt.un"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bgt_Un);
			inst_table["ble.un"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Ble_Un);
			inst_table["blt.un"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Blt_Un);
			inst_table["leave"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Leave);

			inst_table["br.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Br_S);
			inst_table["brfalse.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Brfalse_S);
			inst_table["brtrue.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Brtrue_S);
			inst_table["beq.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Beq_S);
			inst_table["bge.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bge_S);
			inst_table["bgt.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bgt_S);
			inst_table["ble.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Ble_S);
			inst_table["blt.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Blt_S);
			inst_table["bne.un.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bne_Un_S);
			inst_table["bge.un.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bge_Un_S);
			inst_table["bgt.un.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Bgt_Un_S);
			inst_table["ble.un.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Ble_Un_S);
			inst_table["blt.un.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Blt_Un_S);
			inst_table["leave.s"] = new ILToken(Token.INSTR_BRTARGET, OpCodes.Leave_S);

			//
			// Misc other instructions
			//

			inst_table["ldstr"] = new ILToken(Token.INSTR_STRING, OpCodes.Ldstr);
			inst_table["ldc.r4"] = new ILToken(Token.INSTR_R, OpCodes.Ldc_R4);
			inst_table["ldc.r8"] = new ILToken(Token.INSTR_R, OpCodes.Ldc_R8);
			inst_table["ldc.i8"] = new ILToken(Token.INSTR_I8, OpCodes.Ldc_I8);
			inst_table["switch"] = new ILToken(Token.INSTR_SWITCH, OpCodes.Switch);
			inst_table["calli"] = new ILToken(Token.INSTR_SIG, OpCodes.Calli);
			inst_table["ldtoken"] = new ILToken(Token.INSTR_TOK, OpCodes.Ldtoken);
		}
	}
}