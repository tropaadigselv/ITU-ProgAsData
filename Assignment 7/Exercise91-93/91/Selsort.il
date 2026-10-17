  .method public hidebysig static 
        void SelectionSort (
            int32[] arr
        ) cil managed 
    {
        // Method begins at RVA 0x20b8
        // Code size 57 (0x39)
        .maxstack 4                                 // max number of values on the evaluation stack at any point
        .locals init (                              // declares local variables and their slot numbers; init = zero-initialized
            [0] int32 i,
            [1] int32 least,
            [2] int32 tmp,
            [3] int32 j
        )

        IL_0000: ldc.i4.0
        IL_0001: stloc.0                            // i initialized
        // sequence point: hidden
        IL_0002: br.s IL_0032                       // start loop
        // loop start (head: IL_0032)
            IL_0004: ldloc.0
            IL_0005: stloc.1                        // least initialized
            IL_0006: ldloc.0
            IL_0007: ldc.i4.1
            IL_0008: add
            IL_0009: stloc.3                        // j initialized as i+1
            // sequence point: hidden
            IL_000a: br.s IL_001a                   // inner loop
            // loop start (head: IL_001a)
                IL_000c: ldarg.0                    // ld arr
                IL_000d: ldloc.3                    // ld j
                IL_000e: ldelem.i4                  // ld arr[j]; arr and idx are popped from the stack
                IL_000f: ldarg.0                    // ld arr
                IL_0010: ldloc.1                    // ld least
                IL_0011: ldelem.i4                  // arr[least]
                IL_0012: bge.s IL_0016              // if-statement; top two values are arr[j] and arr[least]. Uses >= (opposite of <) and jumps if true

                IL_0014: ldloc.3                    // ld j
                IL_0015: stloc.1                    // put j in least

                IL_0016: ldloc.3                    // ld j
                IL_0017: ldc.i4.1
                IL_0018: add
                IL_0019: stloc.3                    // increment j as the last thing

                IL_001a: ldloc.3
                IL_001b: ldarg.0
                IL_001c: ldlen
                IL_001d: conv.i4
                IL_001e: blt.s IL_000c              // same as IL_0036: evaluate loop cond, now with j
            // end loop

            IL_0020: ldarg.0                        // arr
            IL_0021: ldloc.0                        // i
            IL_0022: ldelem.i4                      // arr[i]
            IL_0023: stloc.2                        // initialize tmp; slot 2 because it's in the outer scope together with least
            IL_0024: ldarg.0                        // arr
            IL_0025: ldloc.0                        // i
            IL_0026: ldarg.0                        // arr
            IL_0027: ldloc.1                        // least
            IL_0028: ldelem.i4                      // arr[least]
            IL_0029: stelem.i4                      // pops arr[least] (value), i (index), arr (array); stores arr[i] = arr[least]
            IL_002a: ldarg.0
            IL_002b: ldloc.1
            IL_002c: ldloc.2
            IL_002d: stelem.i4                      // same as above: arr[least] = tmp
            IL_002e: ldloc.0
            IL_002f: ldc.i4.1
            IL_0030: add
            IL_0031: stloc.0                        // increment i

            IL_0032: ldloc.0
            IL_0033: ldarg.0                        // ld arr
            IL_0034: ldlen
            IL_0035: conv.i4
            IL_0036: blt.s IL_0004                  // evaluate loop cond i < arr.Length; jump back if true, else exit
        // end loop

        IL_0038: ret
    } // end of method Selsort::SelectionSort