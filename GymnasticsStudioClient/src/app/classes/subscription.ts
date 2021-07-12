
export class Subscription {
    public Id :number;
    public Name:string;
    public Price :number;
    public WeeksNum:number;
    public DaysInWeekNum :number;
    public LessonKind:number;
    public StudensKind:number;
    
    constructor(init?: Partial<Subscription>) {
        Object.assign(this, init);
    }
}
