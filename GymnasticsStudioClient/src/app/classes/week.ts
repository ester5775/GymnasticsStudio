export class Week {

    public  WeeklyPortion :string
    public  Note:string
    public  Date :string
    public  Id :number
    constructor(init?: Partial<Week>) {
        Object.assign(this, init);
    }
}
