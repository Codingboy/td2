public enum WorkerMode
{
	Idle,
	OrderRessources,//order required ressources if needed
	GoToProducer,//go to factory
	GoingToProducer,//going to factory
	LoadProducts,//equipe all produced products
	DeliverProducts,//deliver products to orderer
	DeliveringProducts,//delivering products to orderer
	UnloadProducts,//place equiped products in orderers storage
	ProduceProduct,//start producing
	ProduceingProduct,//producing
	ImproveProducts,//start make products better/repair them
	ImproveingProducts,//makeing products better/repair them
	WaitForRessources,//wait until all needed ressources are available in the factory, lock ressources immediately
	Build
}
