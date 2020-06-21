export enum RowStatus {
    Original = <any>"Original" | 0,
    Added = <any>"Added" | 1 << 0,
    Removed = <any>"Removed" | 1 << 1,
    Modified = <any>"Modified" | 1 << 2
}