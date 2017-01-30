import { Skill } from './skill';
import { Tag } from './tag';

export class SkillTag {
  id: number;
  skillId: number;
  skill: Skill;
  tagId: number;
  tag: Tag;
  
  constructor(id: number, skillId: number, skill: Skill, tagId: number, tag: Tag) {
    this.id = id;
    this.skillId = skillId;
    this.skill = skill;
    this.tagId = tagId;
    this.tag = tag;
  }
}
