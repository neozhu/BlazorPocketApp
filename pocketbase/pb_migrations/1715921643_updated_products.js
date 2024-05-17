/// <reference path="../pb_data/types.d.ts" />
migrate((db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("n0jrg4z0jcpicaj")

  // update
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "tv34msy1",
    "name": "unit",
    "type": "select",
    "required": true,
    "presentable": false,
    "unique": false,
    "options": {
      "maxSelect": 1,
      "values": [
        "Packages",
        "Box",
        "Pallet",
        "Carton",
        "Drum"
      ]
    }
  }))

  return dao.saveCollection(collection)
}, (db) => {
  const dao = new Dao(db)
  const collection = dao.findCollectionByNameOrId("n0jrg4z0jcpicaj")

  // update
  collection.schema.addField(new SchemaField({
    "system": false,
    "id": "tv34msy1",
    "name": "unit",
    "type": "select",
    "required": false,
    "presentable": false,
    "unique": false,
    "options": {
      "maxSelect": 1,
      "values": [
        "Packages",
        "Box",
        "Pallet",
        "Carton",
        "Drum"
      ]
    }
  }))

  return dao.saveCollection(collection)
})
