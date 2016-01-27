````c#
	AppInitDB  //  MongoDB连接串，以[mongodb: // ]开头。这里，我们连接的是本机的服务 默认端口27017
    string connectionString = "mongodb://localhost";
    //  连接到一个MongoServer上 
    MongoServer server = MongoServer.Create(connectionString);
    //  打开数据库testdb 
    MongoDatabase database = Common.GetDatabase();

    //插入数据
    var collection = database.GetCollection<Encyclopedia>("Encyclopedia");
    var encyclopedia = new Encyclopedia { Id = Guid.NewGuid().ToString(),thum ="userUpload/1.jpg",date = DateTime.Now,title = "title",content = "content" };
    collection.Insert(encyclopedia);

    //查询数据
    var query = Query<Encyclopedia>.EQ(e => e.title, "title");
    var entity = collection.FindOne(query);

    //查询和修改
    //方式1
    //var query = Query<Encyclopedia>.EQ(e => e.title, "title");
    //var entity = collection.FindOne(query);
    //entity.title = "Title-Dick";
    //collection.Save(entity);
    //方式2
    //var query = Query<Entity>.EQ(e => e.Id, id);
    //var update = Update<Entity>.Set(e => e.Name, "Harry"); // update modifiers
    //collection.Update(query, update);

    //删除
    //var query = Query<Encyclopedia>.EQ(e => e.title, "Title-Dick");
    //var result = collection.Remove(query);
````
