import { Person } from './person';

export class Organization {
  id: number;
  name: string;
  people: Person[];

  constructor(id: number, name: string, people: Person[]) {
    this.id = id;
    this.name = name;
    this.people = people;
  }
}
