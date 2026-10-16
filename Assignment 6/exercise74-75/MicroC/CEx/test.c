void main() {
    int n; int a[5];
    n = 5;
    print ++n;       // 6
    print n;         // 6
    a[1] = 10;
    print --a[1];    // 9, also checks that ++/-- bind looser than [ ]
}