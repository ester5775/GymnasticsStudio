export class Lesson {
    constructor(
        public Id:number,
        public Name:string,
        public TeacherId:string,       
        public Day:string,        
        public Time:string,
        public MaxStudensNum:number,
        public CorrentStudensNum:number,
        ){};
}
