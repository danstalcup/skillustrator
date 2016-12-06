import { SkillTag } from './skill-tag';

export class Tag {
  id: number;
  name: string;
  skills: SkillTag[];

  constructor(id: number, name: string, skills: SkillTag[]) {
    this.id = id;
    this.name = name;
    this.skills = skills;
  }
}
