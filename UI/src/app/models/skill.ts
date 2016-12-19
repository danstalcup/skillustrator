import { Person } from './person';
import { SkillTag } from './skill-tag';

export class Skill {
  id: number;
  name: string;
  people: Person[];
  tags: SkillTag[];

  constructor(name: string) {
    this.name = name;
  }
}
