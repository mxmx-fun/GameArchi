namespace GameArchi.UISystem {

    public class UIFactory {

        //TODO:根据UI资产，创建UI，存储到UIRepo
        public T Create<T>() where T : UIBase, new() {
            return new T();
        }
    }
}