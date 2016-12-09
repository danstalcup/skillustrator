import { PersonSkill } from './person-skill';
import { Organization } from './organization';

export class Person {
  id: number;
  firstName: string;
  lastName: string;
  skills: PersonSkill[];
  organization: Organization;

  constructor(id: number, firstName: string, lastName: string, skills: PersonSkill[], organization: Organization) {
    this.id = id;
    this.firstName = firstName;
    this.lastName = lastName;
    this.skills = skills;
    this.organization = organization;
  }
}
