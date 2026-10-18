void main() {
    int i;
    int arr[4];
    int result;

    // Initialize the array and index
    i = 0;
    arr[0] = 10;
    arr[1] = 20;
    arr[2] = 30;
    arr[3] = 40;

    print 1;

    // Test 1: ++arr[++i]
    result = ++arr[++i];

    print i;       // Expected: 1
    print result;  // Expected: 21
    print arr[0];  // Expected: 10
    print arr[1];  // Expected: 21
    print arr[2];  // Expected: 30

    // Test 2: Execute it again
    result = ++arr[++i];

    print i;       // Expected: 2
    print result;  // Expected: 31
    print arr[1];  // Expected: 21
    print arr[2];  // Expected: 31

    // Test 3: Verify that the index increments only once
    if (i == 2) {
        print 1;   // Expected: 1 (success)
    } else {
        print 0;   // Expected: 0 (failure)
    }

    // Test 4: Verify that the expression returns the updated value
    if (result == 31) {
        print 1;   // Expected: 1 (success)
    } else {
        print 0;   // Expected: 0 (failure)
    }
}