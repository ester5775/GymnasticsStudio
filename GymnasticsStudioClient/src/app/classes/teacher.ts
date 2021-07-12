export class Teacher {

    public Id:number;
    public FirstName :string;
    public LastName :string;
    public IdentityNumber:string;
    public PhoneNumber:string;


    constructor(init?: Partial<Teacher>) {
        Object.assign(this, init);
    }
}
