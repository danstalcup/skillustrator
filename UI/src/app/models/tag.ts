import { SkillTag } from './skill-tag';

export class Tag {
  id: number;
  name: string;
  skills: SkillTag[];

  constructor(name: string) {
    this.name = name;
  }
}
