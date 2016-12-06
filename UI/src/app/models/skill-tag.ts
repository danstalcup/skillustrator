export class SkillTag {
  id: number;
  skillId: number;
  tagId: number;

  constructor(id: number, skillId: number, tagId: number) {
    this.id = id;
    this.skillId = skillId;
    this.tagId = tagId;
  }
}
