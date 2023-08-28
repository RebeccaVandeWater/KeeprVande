export class Vault {
  constructor(data) {
    this.id = data.id
    this.name = data.name
    this.img = data.img
    this.description = data.description
    this.isPrivate = data.isPrivate
    this.createdAt = data.createdAt
    this.updatedAt = data.updatedAt
    this.creator = data.creator
    this.creatorId = data.creatorId
  }
}