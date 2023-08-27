export class Keep {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.img = data.img
    this.description = data.description
    this.kept = data.kept
    this.views = data.views
    this.creatorId = data.creatorId
    this.creator = data.creator
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
  }
}