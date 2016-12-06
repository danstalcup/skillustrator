import { Person } from './person';
import { SkillTag } from './skill-tag';

export class Skill {
  id: number;
  name: string;
  people: Person[];
  tags: SkillTag[];

  constructor(id: number, name: string, people: Person[], tags: SkillTag[]) {
    this.id = id;
    this.name = name;
    this.people = people;
    this.tags = tags;
  }
}
