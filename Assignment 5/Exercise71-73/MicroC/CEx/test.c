void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0;
    *sump = 0;
    while (i < n) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}

void squares(int n, int arr[])
{
    int i;
    for (i = 0; i < n; i = i + 1)
        arr[i] = i * i;  
}

void histogram(int n, int ns[], int max, int freq[])
{
    int i;    
    i = 0;
    while (i <= max) {
        freq[i] = 0;
        i = i + 1;
    }    
    
    for (i = 0; i < n; i = i + 1)
    {
        int idx;
        idx = ns[i];
        freq[idx] = freq[idx] + 1;
    }
}
 
void main() {
    int arr[7];
    int freq[4];     // max + 1 elements
    int i;

    arr[0] = 1; arr[1] = 2; arr[2] = 1; arr[3] = 1;
    arr[4] = 1; arr[5] = 2; arr[6] = 0;

    histogram(7, arr, 3, freq);

    for (i = 0; i < 4; i = i + 1)
        print freq[i];
    println;
}


