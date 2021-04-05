export class Student {
    constructor(
        public Id:number,
        public FirstName:string,
        public LastName:string,
        public IdentityNumber:string,
        public PhoneNumber:string,
        public Pignicher:string,
        public StudentKind:string,
        public Balance:number=0,
        public CreditDetailsId:number=0
        ){};
}
