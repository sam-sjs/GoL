namespace GoL
{
    public interface IRenewable
    {
        public bool DoesCellHaveEnoughNeighboursToStayAlive(Cell cell);
        public bool DoesCellHaveEnoughNeighboursToComeToLife(Cell cell);
    }
}