using Arch.Core;

namespace GameEngine;

public interface ISystem
{
    public void Run(World world);
}