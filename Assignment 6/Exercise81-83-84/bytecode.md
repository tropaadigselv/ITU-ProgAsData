### ex03
````
100 1   [LDARGS 1]
80 1 6  [CALL (1, "L1")]
101     [STOP]

        [Label "L1]	        // main start
62 1    [INCSP 1] 	        // int i;

60      [GETBP]
0 1     [CSTI 1]
10      [ADD]
0 0     [CSTI 0]
41      [STI]
62 -1   [INCSP -1]	        // i = 0;

70 44   [GOTO "L3"]	        // jump to while condition

        [Label "L2]             // while body
        
60      [GETBP]
0 0     [CSTI 1]
10      [ADD]
40      [LDI]
90      [PRINTI]
62 -1   [INCSP -1] 	        // print i;

60      [GETBP]
0 1     [CSTI 1]
10      [ADD]
60      [GETBP]
0 1     [CSTI 1]
10      [ADD]
40      [LDI]
0 1     [CSTI 1]
10      [ADD]
41      [STI]
62 -1   [INCSP -1]	        // i = i + 1;

62 0    [INCSP 0]   	        // end of while body

        [Label "L3"]            // while condition

60      [GETBP]
0 1     [CSTI 1]
10      [ADD]
40      [LDI]         		// load i

60      [GETBP]
0 0     [CSTI 0]
10      [ADD]    
40      [LDI]         		// load n

21      [LT]           		// i < n
72 19   [IFNZRO "L2"] 	        // if true, go to body

62 -1   [INCSP -1]
86 0    [RET 0]                 // return from main

````

### ex05
````
100 1   [LDARGS 1]
80 1 6  [CALL (1, "L1")] 
101     [STOP] 

        [Label "L1"]		    // main start
62 1    [INCSP 1] 		    // int r;

60      [GETBP]
0 1     [CSTI 1] 
10      [ADD]
60      [GETBP] 
0 0     [CSTI 0] 
10      [ADD] 
40      [LDI]
41      [STI] 
62 -1   [INCSP -1] 		    // r = n;

62 1    [INCSP 1] 		    // start new block
			            // int r;
60      [GETBP] 
0 0     [CSTI 0]
10      [ADD] 
40      [LDI]			    // load n

60      [GETBP] 
0 2     [CSTI 2]
10      [ADD]
80 2 58 [CALL (2, "L2")]	    // Call square

62 -1   [INCSP -1] 
60      [GETBP]
0 2     [CSTI 2] 
10      [ADD]
40      [LDI]
90      [PRINTI] 
62 -1   [INCSP -1] 		    // print

62 -1   [INCSP -1] 		    // exit block

60      [GETBP] 
0 1     [CSTI 1]
10      [ADD] 
40      [LDI]
90      [PRINTI] 
62 -1   [INCSP -1]		    // print
62 -1   [INCSP -1]
86 0    [RET 0] 	            // return main

        [Label "L2"] 		    // square start

60      [GETBP] 
0 1     [CSTI 1]
10      [ADD] 
40      [LDI] 			    // load rp (the address pointed to by rp)

60      [GETBP] 
0 0     [CSTI 0]
10      [ADD]
40      [LDI] 			    // load i

60      [GETBP] 
0 0     [CSTI 0]
10      [ADD] 
40      [LDI]			    // load i

12      [MUL] 			    // i * i
41      [STI] 			    // *rp = i * i
62 -1   [INCSP -1] 

62 0    [INCSP 0]
86 1    [RET 1]			    // return square
````